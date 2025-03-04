namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeListVM
    {
        // Needs initialization!
        // In the form, if the variable type (string) is not nullable, then the value in the <form> is null if it is not
        //     added in an <input> field. So, add initial value for each property
        public string Id { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}
