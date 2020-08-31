using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class FlightTicketNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTickets",
                table: "Flight",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTickets",
                table: "Flight");
        }
    }
}
