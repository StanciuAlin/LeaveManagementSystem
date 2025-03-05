namespace LeaveManagementSystem.Web.Services.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserLoggedIn();
        Task<ApplicationUser> GetUserById(string userId);
        Task<List<ApplicationUser>> GetEmployee();
    }
}