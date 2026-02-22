using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatMessage>> GetConversationAsync(long customerId, string receiverRole);
        Task<string> SendMessageAsync(ChatMessage message);
    }
}
