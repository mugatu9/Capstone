using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class UpdateBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AppraisedValue",
                table: "Building",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Building",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppraisedValue",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Building");
        }
    }
}
