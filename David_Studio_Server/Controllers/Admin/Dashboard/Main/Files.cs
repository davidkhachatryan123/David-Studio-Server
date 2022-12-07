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

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ResponseModel> Upload()
        {
            var formFiles = Request.Form.Files;

            IEnumerable<string> filePaths = await _file.UploadAsync(formFiles, _configuration["FilesStorage:Files"]);

            if (filePaths.Count() <= 0)
                return new ResponseModel("File(s) upload error.", StatusCodes.Status500InternalServerError);


            IEnumerable<Database.Models.Content.Uploads.File> files =
                formFiles.Select(x => x.FileName).Zip(filePaths, (name, path) =>
                {
                    return new Database.Models.Content.Uploads.File()
                    {
                        Name = name,
                        Path = path
                    };
                });

            await _uploads.AddFileInfo(files);


            return new ResponseModel("File(s) uploaded successfully.", StatusCodes.Status200OK);
        }
    }
}
