using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class PermissionService : IPermissionService

    {

        private readonly IPermissionRepository _repository;

        public PermissionService(IPermissionRepository repository)

        {

            _repository = repository;

        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()

        {

            return await _repository.GetAllAsync();

        }

        public async Task<Permission> GetPermissionByIdAsync(int id)

        {

            var permission = await _repository.GetByIdAsync(id);

            if (permission == null)

                throw new Exception("Permission not found");

            return permission;

        }

        public async Task<string> CreatePermissionAsync(CreatePermissionDto dto)

        {

            var permission = new Permission

            {

                PermissionName = dto.PermissionName,

                Description = dto.Description

            };

            await _repository.AddAsync(permission);

            await _repository.SaveAsync();

            return "Permission created successfully";

        }

        public async Task<string> DeletePermissionAsync(int id)

        {

            var permission = await _repository.GetByIdAsync(id);

            if (permission == null)

                throw new Exception("Permission not found");

            await _repository.DeleteAsync(permission);

            await _repository.SaveAsync();

            return "Permission deleted successfully";

        }

    }

}
