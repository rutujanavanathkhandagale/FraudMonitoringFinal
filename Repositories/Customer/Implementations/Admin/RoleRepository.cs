using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Data;
using Microsoft.EntityFrameworkCore;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class RoleRepository : IRoleRepository

    {

        private readonly WebContext _context;

        public RoleRepository(WebContext context)

        {

            _context = context;

        }

        public async Task<IEnumerable<Role>> GetAllAsync()

        {

            return await _context.Roles.ToListAsync();

        }

        public async Task<Role?> GetByIdAsync(int id)

        {

            return await _context.Roles.FindAsync(id);

        }

        public async Task<Role?> GetByNameAsync(string roleName)

        {

            return await _context.Roles

                .FirstOrDefaultAsync(r => r.RoleName == roleName);

        }

        public async Task<bool> ExistsByNameAsync(string roleName)

        {

            return await _context.Roles

                .AnyAsync(r => r.RoleName == roleName);

        }

        public async Task AddAsync(Role role)

        {

            await _context.Roles.AddAsync(role);

        }

        public async Task DeleteAsync(Role role)

        {

            _context.Roles.Remove(role);

        }

        public async Task SaveAsync()

        {

            await _context.SaveChangesAsync();

        }

    }
}