using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8", null, "Administrator", "ADMINISTRATOR" },
                    { "9dc37c2d-b6ce-499a-a5b3-2b960661b190", null, "Employee", "EMPLOYEE" },
                    { "a424c086-3755-40cf-a576-259bcbf2766e", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d3041e3-6915-4704-be08-4ccda3988d5c", 0, "c9610ca3-85bb-4ea8-9014-94a19d0498fd", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEjEx3ZXxR8lhKL6x3/YD846MdNHX0Q+jQS6YiyQcfE/N6sOtft/VjI6+uyDHKRX4A==", null, false, "b7e5efcc-1a84-4601-91eb-14da146cda26", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8", "1d3041e3-6915-4704-be08-4ccda3988d5c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dc37c2d-b6ce-499a-a5b3-2b960661b190");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a424c086-3755-40cf-a576-259bcbf2766e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8", "1d3041e3-6915-4704-be08-4ccda3988d5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a2f3db8-5cb7-4f0e-81b4-c849c376e4e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d3041e3-6915-4704-be08-4ccda3988d5c");
        }
    }
}
