namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IRolePermissionService

    {

        Task<string> AssignPermissionAsync(string roleName, int permissionId);

        Task<object> GetRolePermissionsAsync(string roleName);

    }

}