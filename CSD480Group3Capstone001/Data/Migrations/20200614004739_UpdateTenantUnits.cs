using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class UpdateTenantUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairHistory_Unit_UnitID",
                table: "RepairHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairHistory",
                table: "RepairHistory");

            migrationBuilder.AlterColumn<int>(
                name: "UnitID",
                table: "RepairHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RepairHistoryID",
                table: "RepairHistory",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairHistory",
                table: "RepairHistory",
                column: "RepairHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistory_ContractorID",
                table: "RepairHistory",
                column: "ContractorID");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairHistory_Unit_UnitID",
                table: "RepairHistory",
                column: "UnitID",
                principalTable: "Unit",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairHistory_Unit_UnitID",
                table: "RepairHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairHistory",
                table: "RepairHistory");

            migrationBuilder.DropIndex(
                name: "IX_RepairHistory_ContractorID",
                table: "RepairHistory");

            migrationBuilder.DropColumn(
                name: "RepairHistoryID",
                table: "RepairHistory");

            migrationBuilder.AlterColumn<int>(
                name: "UnitID",
                table: "RepairHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairHistory",
                table: "RepairHistory",
                columns: new[] { "ContractorID", "UnitID", "StartDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_RepairHistory_Unit_UnitID",
                table: "RepairHistory",
                column: "UnitID",
                principalTable: "Unit",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
