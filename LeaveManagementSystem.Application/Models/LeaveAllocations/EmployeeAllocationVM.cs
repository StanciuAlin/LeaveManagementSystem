namespace LeaveManagementSystem.Application.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:DD, d MM, yy}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public bool IsCompletedAllocation { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
