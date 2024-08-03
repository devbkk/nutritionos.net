using Microsoft.EntityFrameworkCore;
using NutriCare.Core.Entities;
using NutriCare.Core.Interfaces;
using NutriCare.InfraStructure;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NutriCareDbContext _context;

        public UserRepository(NutriCareDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
           var user =  await _context.Users.FindAsync(id);
           return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
