namespace David_Studio_Server.ViewModels.Dashboard.Main.Files
{
    public class FilesResponseModel
    {
        public IEnumerable<Database.Models.Content.Uploads.File>? Files { get; set; }
        public int TotalCount { get; set; }

        public FilesResponseModel(IEnumerable<Database.Models.Content.Uploads.File>? files, int totalCount)
        {
            Files = files;
            TotalCount = totalCount;
        }
    }
}
