using David_Studio_Server.Database.Models.Content.Uploads;
using David_Studio_Server.Models;
using David_Studio_Server.Models.Auth;
using David_Studio_Server.Services;
using David_Studio_Server.Services.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Main
{
    [Authorize(Roles = UserRoles.Admin)]
    [Authorize(Roles = UserRoles.Manager)]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class Files : ControllerBase
    {
        private readonly IFile _file;
        private readonly IConfiguration _configuration;
        private readonly IUploadsDataProvider _uploads;

        public Files(
            IFile file,
            IConfiguration configuration,
            IUploadsDataProvider uploads)
        {
            _file = file;
            _configuration = configuration;
            _uploads = uploads;
        }

        [HttpPost]
        public async Task<ResponseModel> Upload(List<IFormFile> files)
        {
            IEnumerable<string> filePaths = await _file.UploadAsync(files, _configuration["FilesStorage:Images"]);

            if (filePaths.Count() <= 0)
                return new ResponseModel("File(s) upload error.", StatusCodes.Status500InternalServerError);


            IEnumerable<Image> images = files.Select(x => x.FileName).Zip(filePaths, (name, path) =>
            {
                return new Image()
                {
                    Name = name,
                    Url = path
                };
            });

            await _uploads.AddImagesInfo(images);


            return new ResponseModel("File(s) uploaded successfully.", StatusCodes.Status200OK);
        }
    }
}
