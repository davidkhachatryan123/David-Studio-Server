using David_Studio_Server.Database;
using David_Studio_Server.Database.Models.Authentication;
using David_Studio_Server.Models;
using David_Studio_Server.Models.Auth;
using David_Studio_Server.Models.Dashboard;
using David_Studio_Server.Models.Dashboard.Main.Files;
using David_Studio_Server.Services;
using David_Studio_Server.Services.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Controllers.Admin.Dashboard.Main
{
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Manager)]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class Files : ControllerBase
    {
        private readonly IFile _file;
        private readonly IConfiguration _configuration;
        private readonly IUploadsDataProvider _uploads;
        private readonly DavidStudioContext _context;

        public Files(
            IFile file,
            IConfiguration configuration,
            IUploadsDataProvider uploads,
            DavidStudioContext context)
        {
            _file = file;
            _configuration = configuration;
            _uploads = uploads;
            _context = context;
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

        Func<Database.Models.Content.Uploads.File, Object> orderByFunc = null!;

        [HttpGet]
        public async Task<FilesResponseModel> GetList([FromQuery] TableOptions options)
        {
            switch (options.Sort.ToLower())
            {
                case FilesSort.Id:
                    orderByFunc = x => x.Id;
                    break;
                case FilesSort.Name:
                    orderByFunc = x => x.Name;
                    break;
            }

            IEnumerable<Database.Models.Content.Uploads.File> files = _context.Files;

            files = options.OrderDirection == "asc" ?
                files.OrderBy(orderByFunc) : files.OrderByDescending(orderByFunc);

            files = files.Skip((options.Page - 1) * options.PageSize)
                         .Take(options.PageSize);

            return new FilesResponseModel(files, await _context.Files.CountAsync());
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteFile([FromQuery] int Id)
        {
            Database.Models.Content.Uploads.File file = await _context.Files.FirstAsync(x => x.Id == Id);

            if (file != null)
            {
                _context.Files.Remove(file);
                await _context.SaveChangesAsync();

                bool result = _file.RemoveFile(file.Path);


                return ResponseModel.GetResponse(
                    result,
                    "File successfully deleted!", StatusCodes.Status200OK,
                    "Internal server error, please try again later!", StatusCodes.Status500InternalServerError);
            }
            else
                return new ResponseModel("File not found!", StatusCodes.Status404NotFound);
        }
    }
}
