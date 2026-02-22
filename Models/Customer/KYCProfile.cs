using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Customer
{
    public class KYCProfile
    {
        [Key]
        public long KYCId { get; set; }

        [Required]
        public long CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("Pending|Verified|Rejected", ErrorMessage = "Status must be Pending, Verified, or Rejected")]
        public string Status { get; set; } = "Pending";

        [DataType(DataType.Date)]
        public DateTime? LastReviewedDate { get; set; }

        [Required(ErrorMessage = "Documents are required")]
        public string DocumentRefsJSON { get; set; }

        [ForeignKey("CustomerId")]
        [ValidateNever]
        public PersonalDetails Customer { get; set; }
    }
}
