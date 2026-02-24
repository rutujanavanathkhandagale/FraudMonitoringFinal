namespace FraudMonitoringSystem.Exceptions.Roles
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}