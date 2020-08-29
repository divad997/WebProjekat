using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class IdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_AirCompanies_AirCompanyId",
                table: "Destination");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "LId");

            migrationBuilder.AddColumn<string>(
                name: "Rating1",
                table: "Rating",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AirCompanyId",
                table: "Destination",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_AirCompanies_AirCompanyId",
                table: "Destination",
                column: "AirCompanyId",
                principalTable: "AirCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_AirCompanies_AirCompanyId",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "Rating1",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "LId",
                table: "Location",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "AirCompanyId",
                table: "Destination",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_AirCompanies_AirCompanyId",
                table: "Destination",
                column: "AirCompanyId",
                principalTable: "AirCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
