using FraudMonitoringSystem.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Models;
namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
   

    public interface IRegistrationService
    {
        Task<string> RegisterUserAsync(Registration reg);
        Task<Registration> GetUserByIdAsync(int id);
        Task<Registration> GetUserByEmailAsync(string email);
        Task<List<Registration>> GetAllUsersAsync();
        Task<string> UpdateUserAsync(Registration reg);
        Task<string> DeleteUserAsync(int id);
    }
}
