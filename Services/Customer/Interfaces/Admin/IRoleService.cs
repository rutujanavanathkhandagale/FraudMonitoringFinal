using FraudMonitoringSystem.DTOs.Admin;
namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin

{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync();
        Task<RoleResponseDto?> GetRoleByIdAsync(int id);
        Task<string> CreateRoleAsync(CreateRoleDto dto);
        Task<string> DeleteRoleByNameAsync(string roleName);
        Task<string> AssignPermissionToRoleAsync(AssignPermissionDto dto);
    }
}