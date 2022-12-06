﻿using David_Studio_Server.Controllers.Admin.Dashboard.Main;

namespace David_Studio_Server.Services
{
    public interface IFile
    {
        Task<IEnumerable<string>> UploadAsync(List<IFormFile> files, string storedFilePath);
    }

    public class File : IFile
    {
        public async Task<IEnumerable<string>> UploadAsync(List<IFormFile> files, string storedFilePath)
        {
            List<string> filePaths = new List<string>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(
                        storedFilePath,
                        Guid.NewGuid().ToString() +
                        formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")));

                    filePaths.Add(filePath);

                    using (var stream = System.IO.File.Create(Path.Combine("wwwroot", filePath)))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return filePaths;
        }
    }
}
