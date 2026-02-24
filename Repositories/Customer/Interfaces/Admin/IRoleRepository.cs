using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface IRoleRepository

    {

        Task<IEnumerable<Role>> GetAllAsync();

        Task<Role?> GetByIdAsync(int id);

        Task<Role?> GetByNameAsync(string roleName);

        Task<bool> ExistsByNameAsync(string roleName);

        Task AddAsync(Role role);

        Task DeleteAsync(Role role);

        Task SaveAsync();

    }
}