using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Repositories.Customer.Implementations.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;


namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class PermissionRepository : IPermissionRepository

    {

        private readonly WebContext _context;

        public PermissionRepository(WebContext context)

        {

            _context = context;

        }

        public async Task<IEnumerable<Permission>> GetAllAsync()

        {

            return await _context.Permissions.ToListAsync();

        }

        public async Task<Permission?> GetByIdAsync(int id)

        {

            return await _context.Permissions.FindAsync(id);

        }

        public async Task AddAsync(Permission permission)

        {

            await _context.Permissions.AddAsync(permission);

        }

        public async Task DeleteAsync(Permission permission)

        {

            _context.Permissions.Remove(permission);

        }

        public async Task SaveAsync()

        {

            await _context.SaveChangesAsync();

        }

    }

}
