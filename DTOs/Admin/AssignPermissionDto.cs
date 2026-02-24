namespace FraudMonitoringSystem.DTOs.Admin
{
    public class AssignPermissionDto
    {
        public string RoleName { get; set; } = string.Empty;
        public int PermissionId { get; set; }
    }
}