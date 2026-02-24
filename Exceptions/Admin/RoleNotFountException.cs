namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException(string message) : base(message)
        {
        }
    }
}