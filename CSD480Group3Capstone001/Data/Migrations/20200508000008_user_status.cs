using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class user_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Employer = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    MovedInDate = table.Column<DateTime>(nullable: false),
                    MovedOutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
