namespace David_Studio_Server.Models.Dashboard.Users
{
    public class UsersResponse
    {
        public IEnumerable<User>? Users { get; set; }
        public int TotalCount { get; set; }

        public UsersResponse(IEnumerable<User>? users, int totalCount)
        {
            Users = users;
            TotalCount = totalCount;
        }
    }
}
