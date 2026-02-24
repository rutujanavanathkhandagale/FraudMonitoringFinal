using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.Models.Admin
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public int RoleId { get; set; }   // FK
        public Role? Role { get; set; }   // Navigation
    }
}
