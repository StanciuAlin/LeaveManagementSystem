using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    // Because the initial name of this class: IndexVM not matching the others views, rename it.
    // The decision if we create a separate ViewModel for each View is by project requirements, now we will
    //   use the same ViewModel for all Views (Details, Create, Edit) because they use the same fields like 
    //   the initial ViewModel class IndexVM
    // Now, the IndexVM is renamed to LeaveTypeReadOnlyVM
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Max allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
