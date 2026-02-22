using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly WebContext _context;

        public ChatRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<List<ChatMessage>> GetMessagesAsync(long customerId, string receiverRole)
        {
            return await _context.ChatMessages
                .Where(m => m.CustomerId == customerId && m.ReceiverRole == receiverRole)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<int> AddMessageAsync(ChatMessage message)
        {
            await _context.ChatMessages.AddAsync(message);
            return await _context.SaveChangesAsync();
        }
    }
}

