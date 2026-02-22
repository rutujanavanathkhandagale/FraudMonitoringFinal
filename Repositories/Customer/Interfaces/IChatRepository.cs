using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{
    public interface IChatRepository
    {
        Task<List<ChatMessage>> GetMessagesAsync(long customerId, string receiverRole);
        Task<int> AddMessageAsync(ChatMessage message);
    }
}
