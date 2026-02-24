using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Exceptions.Admin;


namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class RoleService : IRoleService

    {

        private readonly IRoleRepository _repository;

        private readonly WebContext _context;

        public RoleService(IRoleRepository repository,

                           WebContext context)

        {

            _repository = repository;

            _context = context;

        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync()

        {

            var roles = await _repository.GetAllAsync();

            return roles.Select(r => new RoleResponseDto

            {

                RoleId = r.RoleId,

                RoleName = r.RoleName,

                Description = r.Description

            });

        }

        public async Task<RoleResponseDto?> GetRoleByIdAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null)
                return null;
            return new RoleResponseDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        public async Task<string> CreateRoleAsync(CreateRoleDto dto)

        {

            if (await _repository.ExistsByNameAsync(dto.RoleName))

                throw new RoleAlreadyExistsException("Role already exists");

            var role = new Role

            {

                RoleName = dto.RoleName,

                Description = dto.Description,

                CreatedAt = DateTime.UtcNow

            };

            await _repository.AddAsync(role);

            await _repository.SaveAsync();

            return "Role created successfully";

        }

        public async Task<string> DeleteRoleByNameAsync(string roleName)

        {

            var role = await _repository.GetByNameAsync(roleName);

            if (role == null)

                throw new RoleNotFoundException("Role not found");

            await _repository.DeleteAsync(role);



            return "Role deleted successfully";

        }

        public async Task<string> AssignPermissionToRoleAsync(AssignPermissionDto dto)

        {

            var role = await _repository.GetByNameAsync(dto.RoleName);

            if (role == null)

                throw new RoleNotFoundException("Role not found");

            var permission = await _context.Permissions

                .FindAsync(dto.PermissionId);

            if (permission == null)

                throw new Exception("Permission not found");

            var rolePermission = new RolePermission

            {

                RoleId = role.RoleId,

                PermissionId = dto.PermissionId

            };

            await _context.RolePermissions.AddAsync(rolePermission);

            await _context.SaveChangesAsync();

            return "Permission assigned successfully";

        }
    }
}