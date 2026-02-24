using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface IRolePermissionRepository
    {
        Task AssignPermissionAsync(int roleId, int permissionId);
        Task SaveAsync();
        Task<IEnumerable<RolePermission>> GetRolePermissionsAsync(int roleId);
    }
}