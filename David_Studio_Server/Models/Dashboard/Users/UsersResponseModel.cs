namespace David_Studio_Server.Models.Dashboard.Users
{
    public class UsersResponseModel
    {
        public IEnumerable<UserViewModel>? Users { get; set; }
        public int TotalCount { get; set; }

        public UsersResponseModel(IEnumerable<UserViewModel>? users, int totalCount)
        {
            Users = users;
            TotalCount = totalCount;
        }
    }
}
