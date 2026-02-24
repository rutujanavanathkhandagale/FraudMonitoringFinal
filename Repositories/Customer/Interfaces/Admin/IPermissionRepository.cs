using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission?> GetByIdAsync(int id);
        Task AddAsync(Permission permission);
        Task DeleteAsync(Permission permission);
        Task SaveAsync();
    }
}
