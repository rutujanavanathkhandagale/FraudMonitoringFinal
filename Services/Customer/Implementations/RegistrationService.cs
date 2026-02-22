using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Exceptions.Customer;
using FraudMonitoringSystem.Helpers;
using FraudMonitoringSystem.Models;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;
namespace FraudMonitoringSystem.Services.Customer.Implementations
{
   

    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository repo;
        private readonly EmailHelper emailHelper;

        public RegistrationService(IRegistrationRepository repository, EmailHelper helper)
        {
            repo = repository;
            emailHelper = helper;
        }

        public async Task<string> RegisterUserAsync(Registration reg)
        {
            var existingUser = await repo.GetUserByEmailAsync(reg.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException($"User with email {reg.Email} already exists");
            }

            await repo.RegisterUserAsync(reg);
            await emailHelper.SendConfirmationEmailAsync(reg.Email, reg.CustomerId);

            return $"Registration successful! Your Customer ID is {reg.CustomerId}";
        }

        public async Task<Registration> GetUserByIdAsync(int id)
        {
            var user = await repo.GetUserByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException($"User with ID {id} not found");
            return user;
        }

        public async Task<Registration> GetUserByEmailAsync(string email)
        {
            var user = await repo.GetUserByEmailAsync(email);
            if (user == null)
                throw new UserNotFoundException($"User with email {email} not found");
            return user;
        }

        public async Task<List<Registration>> GetAllUsersAsync()
        {
            return await repo.GetAllUsersAsync();
        }

        public async Task<string> UpdateUserAsync(Registration reg)
        {
            var existingUser = await repo.GetUserByIdAsync(reg.CustomerId);
            if (existingUser == null)
                throw new UserNotFoundException($"User with ID {reg.CustomerId} not found");

            // Update tracked entity
            existingUser.FirstName = reg.FirstName;
            existingUser.LastName = reg.LastName;
            existingUser.Email = reg.Email;
            existingUser.PhoneNo = reg.PhoneNo;
            existingUser.Password = reg.Password;
            existingUser.ConfirmPassword = reg.ConfirmPassword;

            await repo.UpdateUserAsync(existingUser);
            return $"User with ID {reg.CustomerId} updated successfully";
        }


        public async Task<string> DeleteUserAsync(int id)
        {
            var existingUser = await repo.GetUserByIdAsync(id);
            if (existingUser == null)
                throw new UserNotFoundException($"User with ID {id} not found");

            await repo.DeleteUserAsync(id);
            return $"User with ID {id} deleted successfully";
        }
    }
}
