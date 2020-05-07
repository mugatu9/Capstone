using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD480Group3Capstone001.Data.Migrations
{
    public partial class initial_create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentPayment_Unit_UnitID",
                table: "RentPayment");

            migrationBuilder.DropTable(
                name: "TaxParcel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentPayment",
                table: "RentPayment");

            migrationBuilder.DropIndex(
                name: "IX_RentPayment_UnitID",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "RentPayment");

            migrationBuilder.AddColumn<int>(
                name: "RentPaymentID",
                table: "RentPayment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxParcelAmount",
                table: "Building",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxParcelYear",
                table: "Building",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentPayment",
                table: "RentPayment",
                column: "RentPaymentID");

            migrationBuilder.CreateTable(
                name: "TenantUnits",
                columns: table => new
                {
                    TenantID = table.Column<int>(nullable: false),
                    UnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUnits", x => new { x.TenantID, x.UnitID });
                    table.ForeignKey(
                        name: "FK_TenantUnits_Tenant_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenant",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUnits_Unit_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Unit",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentPayment_TenantID",
                table: "RentPayment",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUnits_UnitID",
                table: "TenantUnits",
                column: "UnitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentPayment",
                table: "RentPayment");

            migrationBuilder.DropIndex(
                name: "IX_RentPayment_TenantID",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "RentPaymentID",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "TaxParcelAmount",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "TaxParcelYear",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "RentPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentPayment",
                table: "RentPayment",
                columns: new[] { "TenantID", "UnitID", "Date" });

            migrationBuilder.CreateTable(
                name: "TaxParcel",
                columns: table => new
                {
                    TaxParcelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    BuildingID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxParcel", x => x.TaxParcelID);
                    table.ForeignKey(
                        name: "FK_TaxParcel_Building_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentPayment_UnitID",
                table: "RentPayment",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxParcel_BuildingID",
                table: "TaxParcel",
                column: "BuildingID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentPayment_Unit_UnitID",
                table: "RentPayment",
                column: "UnitID",
                principalTable: "Unit",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
