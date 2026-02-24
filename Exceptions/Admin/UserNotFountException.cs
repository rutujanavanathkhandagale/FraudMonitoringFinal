namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}