using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [DisplayName("Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public DateOnly EndDate { get; set; }
        
        [DisplayName("Choose Leave Type")]
        [Required]
        // A view model never referencing a data model, so only the Id, no the entire object of LeaveType type
        public int LeaveTypeId { get; set; }
        
        [DisplayName("Additional Information")]
        [StringLength(250)]
        public string? RequestComments { get; set; } = string.Empty;

        public SelectList? LeaveTypes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date must be before the End Date", 
                    [nameof(StartDate), nameof(EndDate)]);
            }


        }
    }
}