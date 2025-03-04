using LeaveManagementSystem.Web.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeaveManagementSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // To avoid all this lines, use builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());
        //builder.ApplyConfiguration(new IdentityRoleConfiguration());
        //builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        //builder.ApplyConfiguration(new ApplicationUserConfiguration());
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

}
