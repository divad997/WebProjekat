using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class FlightChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LId",
                table: "Location",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "DestinationFrom",
                table: "Flight",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationTo",
                table: "Flight",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationFrom",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DestinationTo",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "LId");
        }
    }
}
