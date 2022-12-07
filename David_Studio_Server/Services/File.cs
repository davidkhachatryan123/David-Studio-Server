using David_Studio_Server.Controllers.Admin.Dashboard.Main;

namespace David_Studio_Server.Services
{
    public interface IFile
    {
        Task<IEnumerable<string>> UploadAsync(IFormFileCollection files, string storedFilePath);
        bool RemoveFile(string filePath);
    }

    public class File : IFile
    {
        public async Task<IEnumerable<string>> UploadAsync(IFormFileCollection files, string storedFilePath)
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

        public bool RemoveFile(string filePath)
        {
            if (System.IO.File.Exists(Path.Combine("wwwroot", filePath)))
            {
                System.IO.File.Delete(Path.Combine("wwwroot", filePath));


                return true;
            }

            return false;
        }
    }
}
