using Microsoft.AspNetCore.Http;

namespace LeaveManagementSystem.Application.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager,
    IHttpContextAccessor _httpContextAccessor) : IUserService
{

    public async Task<ApplicationUser> GetUserLoggedIn()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        return user;
    }
    public async Task<ApplicationUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public async Task<List<ApplicationUser>> GetEmployee()
    {
        var employee = await _userManager.GetUsersInRoleAsync(Roles.Employee);
        return employee.ToList();
    }
}
