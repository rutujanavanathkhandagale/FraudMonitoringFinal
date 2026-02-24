using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;


namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class RolePermissionRepository(WebContext context) : IRolePermissionRepository

    {

        private readonly WebContext _context = context;

        public async Task AssignPermissionAsync(int roleId, int permissionId)

        {

            var rolePermission = new RolePermission

            {

                RoleId = roleId,

                PermissionId = permissionId

            };

            await _context.RolePermissions.AddAsync(rolePermission);

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<RolePermission>> GetRolePermissionsAsync(int roleId)

        {

            return await _context.RolePermissions

                .Include(rp => rp.Permission)

                .Where(rp => rp.RoleId == roleId)

                .ToListAsync();

        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}