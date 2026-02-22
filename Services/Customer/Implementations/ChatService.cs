using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using FraudMonitoringSystem.Exceptions.Customer;
namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repo;

        public ChatService(IChatRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ChatMessage>> GetConversationAsync(long customerId, string receiverRole)
        {
            var messages = await _repo.GetMessagesAsync(customerId, receiverRole);
            if (messages == null || messages.Count == 0)
                throw new ChatNotFoundException($"No chat found between Customer {customerId} and {receiverRole}");
            return messages;
        }

        public async Task<string> SendMessageAsync(ChatMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.Message))
                throw new ChatValidationException("Message cannot be empty");

            if (string.IsNullOrWhiteSpace(message.ReceiverRole))
                throw new ChatValidationException("ReceiverRole must be specified");

            message.SentAt = DateTime.UtcNow;
            await _repo.AddMessageAsync(message);
            return $"Message sent to {message.ReceiverRole} successfully";
        }
    }
}
