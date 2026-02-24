using FraudMonitoringSystem.DTOs.Admin;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<string> CreateUserAsync(CreateUserDto dto);
        Task<string> DeleteUserAsync(int id);
    }
}