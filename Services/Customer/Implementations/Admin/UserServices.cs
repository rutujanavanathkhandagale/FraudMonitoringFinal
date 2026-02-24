using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;

using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Exceptions.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class UserService : IUserService

    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)

        {

            _repository = repository;

        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()

        {

            var users = await _repository.GetAllAsync();

            return users.Select(u => new UserResponseDto

            {

                Id = u.Id,

                Username = u.Username,

                Email = u.Email,

                RoleName = u.Role != null ? u.Role.RoleName : ""

            });

        }

        public async Task<UserResponseDto> GetByIdAsync(int id)

        {

            var user = await _repository.GetByIdAsync(id);

            if (user == null)

                throw new UserNotFoundException("User not found");

            return new UserResponseDto

            {

                Id = user.Id,

                Username = user.Username,

                Email = user.Email,

                RoleName = user.Role != null ? user.Role.RoleName : ""

            };

        }

        public async Task<string> CreateUserAsync(CreateUserDto dto)

        {

            var existingEmail = await _repository.GetByEmailAsync(dto.Email);

            if (existingEmail != null)

                throw new UserAlreadyExistsException("Email already exists");

            var existingUsername = await _repository.GetByUsernameAsync(dto.Username);

            if (existingUsername != null)

                throw new UserAlreadyExistsException("Username already exists");

            var user = new User

            {

                Username = dto.Username,

                Email = dto.Email,

                Password = dto.Password,

                RoleId = dto.RoleId

            };

            await _repository.AddAsync(user);

            await _repository.SaveAsync();

            return "User created successfully";

        }

        public async Task<string> DeleteUserAsync(int id)

        {

            var user = await _repository.GetByIdAsync(id);

            if (user == null)

                throw new UserNotFoundException("User not found");

            await _repository.DeleteAsync(user);

            await _repository.SaveAsync();

            return "User deleted successfully";

        }

    }

}