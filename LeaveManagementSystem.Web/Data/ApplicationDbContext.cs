using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "9dc37c2d-b6ce-499a-a5b3-2b960661b190",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole
            {
                Id = "a424c086-3755-40cf-a576-259bcbf2766e",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            },
            new IdentityRole
            {
                Id = "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );

        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
        {
            Id = "1d3041e3-6915-4704-be08-4ccda3988d5c",
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            FirstName = "Default",
            LastName = "Admin",
            DateOfBirth = new DateOnly(2000, 1, 1)
        });

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8",
                UserId = "1d3041e3-6915-4704-be08-4ccda3988d5c"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
}
