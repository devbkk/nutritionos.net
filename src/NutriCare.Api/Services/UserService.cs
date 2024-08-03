using NutriCare.Api.Interfaces;
using NutriCare.Api.Models.Response;
namespace NutriCare.Api.Services
{
    public class UserService : IUserService
    {
        public async Task<List<UserResponseModel>> GetUsers()
        {
            List<UserResponseModel> users = await FetchUsersAsync();

            return users;
        }
        private async Task<List<UserResponseModel>> FetchUsersAsync()
        {
            // Simulate fetching users from a database or other data source
            List<UserResponseModel> users = new List<UserResponseModel>
            {
                new UserResponseModel { UserId = new Guid(), Username = "Alice", Email = "user1@company.com" },
                new UserResponseModel { UserId = new Guid(), Username = "Bob", Email = "user2@company.com" },
                // Add more users as needed
            };

            // Simulate an asynchronous delay (replace with actual data retrieval)
            await Task.Delay(100); // Adjust the delay as needed

            return users;
        }
    }
}