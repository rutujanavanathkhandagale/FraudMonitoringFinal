namespace FraudMonitoringSystem.Models.Customer
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }      
        public string SenderRole { get; set; }    
        public string ReceiverRole { get; set; }  
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
