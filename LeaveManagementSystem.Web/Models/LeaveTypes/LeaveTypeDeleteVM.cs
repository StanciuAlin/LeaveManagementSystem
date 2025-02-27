using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    // DIY, nu am folosit aceasta clasa, am folosit tot clasa ReadOnly
    // Clasa scrisa doar pentru consistenta, insa nu a fost utilizata
    public class LeaveTypeDeleteVM : BaseLeaveTypeVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "You have violated the length requirements")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 90)]
        [Display(Name = "Max allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
