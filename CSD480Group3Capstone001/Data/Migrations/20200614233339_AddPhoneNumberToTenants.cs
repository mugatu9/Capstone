using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class AddPhoneNumberToTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tenant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tenant");
        }
    }
}
