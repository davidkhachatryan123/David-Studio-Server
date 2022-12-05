namespace David_Studio_Server.Models.Dashboard.Users
{
    public class UsersResponseModel
    {
        public IEnumerable<UserModel>? Users { get; set; }
        public int TotalCount { get; set; }

        public UsersResponseModel(IEnumerable<UserModel>? users, int totalCount)
        {
            Users = users;
            TotalCount = totalCount;
        }
    }
}
