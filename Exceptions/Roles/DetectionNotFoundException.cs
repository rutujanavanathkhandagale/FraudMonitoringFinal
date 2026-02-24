namespace FraudMonitoringSystem.Exceptions.Roles
{
    public class DetectionNotFoundException : Exception
    {
        public DetectionNotFoundException(string message) : base(message) { }
    }
}