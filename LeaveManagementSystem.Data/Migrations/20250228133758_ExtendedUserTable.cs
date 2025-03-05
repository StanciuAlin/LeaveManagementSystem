using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d3041e3-6915-4704-be08-4ccda3988d5c",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e66e4d9-f0c9-496c-aa06-6d9be5bab527", new DateOnly(2000, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAECms7UDGalRaDpIZRnDmnWfqtH46XraGZfMiw4MTJI+woJ/JesOJZb4n78FH2gI3Mw==", "e925b896-feb3-41d7-aedc-68403963cb08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d3041e3-6915-4704-be08-4ccda3988d5c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9610ca3-85bb-4ea8-9014-94a19d0498fd", "AQAAAAIAAYagAAAAEEjEx3ZXxR8lhKL6x3/YD846MdNHX0Q+jQS6YiyQcfE/N6sOtft/VjI6+uyDHKRX4A==", "b7e5efcc-1a84-4601-91eb-14da146cda26" });
        }
    }
}
