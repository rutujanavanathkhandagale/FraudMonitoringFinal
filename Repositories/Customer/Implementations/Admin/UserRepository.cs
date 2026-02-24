using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class UserRepository : IUserRepository

    {

        private readonly WebContext _context;

        public UserRepository(WebContext context)

        {

            _context = context;

        }

        public async Task<IEnumerable<User>> GetAllAsync()

        {

            return await _context.Users

                .Include(u => u.Role)

                .ToListAsync();

        }

        public async Task<User?> GetByIdAsync(int id)

        {

            return await _context.Users

                .Include(u => u.Role)

                .FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<User?> GetByEmailAsync(string email)

        {

            return await _context.Users

                .FirstOrDefaultAsync(u => u.Email == email);

        }

        public async Task<User?> GetByUsernameAsync(string username)

        {

            return await _context.Users

                .FirstOrDefaultAsync(u => u.Username == username);

        }

        public async Task AddAsync(User user)

        {

            await _context.Users.AddAsync(user);

        }

        public Task DeleteAsync(User user)

        {

            _context.Users.Remove(user);

            return Task.CompletedTask;

        }

        public async Task SaveAsync()

        {

            await _context.SaveChangesAsync();

        }

    }

}
