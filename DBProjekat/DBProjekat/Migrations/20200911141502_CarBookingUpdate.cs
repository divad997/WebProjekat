using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class CarBookingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CarBookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PassportNum",
                table: "CarBookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "CarBookings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_LocationId",
                table: "CarBookings",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_Location_LocationId",
                table: "CarBookings",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_Location_LocationId",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_LocationId",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "PassportNum",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "CarBookings");
        }
    }
}
