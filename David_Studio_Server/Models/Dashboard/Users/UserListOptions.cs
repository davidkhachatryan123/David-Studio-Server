namespace David_Studio_Server.Models.Dashboard.Users
{
    public class UserListOptions
    {
        public string Sort { get; set; } = null!;
        public string OrderDirection { get; set; } = null!;
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
