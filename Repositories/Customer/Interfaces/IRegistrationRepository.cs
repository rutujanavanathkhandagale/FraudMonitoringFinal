using FraudMonitoringSystem.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Models;
namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{
 

    public interface IRegistrationRepository
    {
        Task<int> RegisterUserAsync(Registration reg);
        Task<Registration?> GetUserByIdAsync(int id);
        Task<Registration?> GetUserByEmailAsync(string email);
        Task<List<Registration>> GetAllUsersAsync();
        Task<int> UpdateUserAsync(Registration reg);
        Task<int> DeleteUserAsync(int id);
    }
}
