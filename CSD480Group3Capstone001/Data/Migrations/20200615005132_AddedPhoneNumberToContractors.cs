using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class AddedPhoneNumberToContractors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Contractor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Contractor");
        }
    }
}
