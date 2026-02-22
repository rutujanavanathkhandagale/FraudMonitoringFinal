using Microsoft.AspNetCore.SignalR;

namespace FraudMonitoringSystem.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderRole, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", senderRole, message);
        }
    }
}

