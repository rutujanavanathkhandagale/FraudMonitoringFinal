using FraudMonitoringSystem.Models.Customer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
   

    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly WebContext _context;

        public RegistrationRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterUserAsync(Registration reg)
        {
            await _context.Registrations.AddAsync(reg);
            return await _context.SaveChangesAsync();
        }

        public async Task<Registration?> GetUserByIdAsync(int id)
        {
            return await _context.Registrations.FindAsync(id);
        }

        public async Task<Registration?> GetUserByEmailAsync(string email)
        {
            return await _context.Registrations.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<Registration>> GetAllUsersAsync()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<int> UpdateUserAsync(Registration reg)
        {
            _context.Registrations.Update(reg);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var user = await _context.Registrations.FindAsync(id);
            if (user != null)
            {
                _context.Registrations.Remove(user);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
