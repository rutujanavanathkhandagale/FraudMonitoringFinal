using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        public RolePermissionService(
            IRolePermissionRepository repository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }
        public async Task<string> AssignPermissionAsync(string roleName, int permissionId)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            if (role == null)
                throw new Exception("Role not found");
            var permission = await _permissionRepository.GetByIdAsync(permissionId);
            if (permission == null)
                throw new Exception("Permission not found");
            await _repository.AssignPermissionAsync(role.RoleId, permissionId);
            return "Permission assigned successfully";
        }
        public async Task<object> GetRolePermissionsAsync(string roleName)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            if (role == null)
                throw new Exception("Role not found");
            var permissions = await _repository.GetRolePermissionsAsync(role.RoleId);
            return permissions.Select(p => new
            {
                p.Permission.PermissionName,
                p.Permission.Description
            });
        }
    }
}