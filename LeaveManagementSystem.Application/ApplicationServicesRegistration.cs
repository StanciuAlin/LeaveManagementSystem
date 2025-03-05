using LeaveManagementSystem.Application.Services.Email;
using LeaveManagementSystem.Application.Services.LeaveAllocations;
using LeaveManagementSystem.Application.Services.LeaveRequests;
using LeaveManagementSystem.Application.Services.LeaveTypes;
using LeaveManagementSystem.Application.Services.Periods;
using LeaveManagementSystem.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagementSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        // Extension method: Extending Application services that we can register in our web application
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // AddTransient lifetime services are created each time they are requested. Eg: Make API calls
            // AddScoped lifetime services are created once per request. Eg: Controller and action
            // AddSingleton lifetime services are created the first time they are requested and then every subsequent request will use the same instance.
            //    Good for static resource or a file that has to be present all the time

            // Moved from Web project because make more sense to be placed here
            services.AddScoped<ILeaveTypesService, LeaveTypesService>();
            services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
            services.AddScoped<ILeaveRequestsService, LeaveRequestsService>();
            services.AddScoped<IPeriodsService, PeriodsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
