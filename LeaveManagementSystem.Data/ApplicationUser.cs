namespace LeaveManagementSystem.Data
{
    public class ApplicationUser : IdentityUser // Inherit from ApplicationUser to have all the other columns from table
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
