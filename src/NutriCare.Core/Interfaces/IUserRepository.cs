using NutriCare.Core.Entities;

namespace NutriCare.Core.Interfaces
{
  public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
    }
}