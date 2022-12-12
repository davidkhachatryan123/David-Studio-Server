namespace David_Studio_Server.ViewModels.Dashboard
{
    public class TableOptions
    {
        public string Sort { get; set; } = null!;
        public string OrderDirection { get; set; } = null!;
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
