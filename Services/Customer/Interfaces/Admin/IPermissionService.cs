using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IPermissionService

    {

        Task<IEnumerable<Permission>> GetAllPermissionsAsync();

        Task<Permission> GetPermissionByIdAsync(int id);

        Task<string> CreatePermissionAsync(CreatePermissionDto dto);

        Task<string> DeletePermissionAsync(int id);

    }

}
