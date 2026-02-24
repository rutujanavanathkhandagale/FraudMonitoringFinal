using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task SaveAsync();
    }
}