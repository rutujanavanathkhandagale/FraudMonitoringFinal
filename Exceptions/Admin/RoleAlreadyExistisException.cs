namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class RoleAlreadyExistsException : Exception
    {
        public RoleAlreadyExistsException(string message)
            : base(message) { }
    }
}