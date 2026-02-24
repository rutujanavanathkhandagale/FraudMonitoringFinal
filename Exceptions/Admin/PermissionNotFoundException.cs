namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class PermissionNotFoundException : Exception
    {
        public PermissionNotFoundException(string message) : base(message) { }
    }
}