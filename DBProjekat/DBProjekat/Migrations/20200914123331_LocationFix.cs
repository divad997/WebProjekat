using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class LocationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_RentCompanies_RentCompanyId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "RentCompanyId",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_RentCompanies_RentCompanyId",
                table: "Locations",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_RentCompanies_RentCompanyId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "RentCompanyId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_RentCompanies_RentCompanyId",
                table: "Locations",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
