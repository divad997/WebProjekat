using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class TicketAdd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Rating",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationFrom = table.Column<string>(nullable: false),
                    DestinationTo = table.Column<string>(nullable: false),
                    TakeoffDate = table.Column<DateTime>(nullable: false),
                    LandingDate = table.Column<DateTime>(nullable: false),
                    TakeoffTime = table.Column<DateTime>(nullable: false),
                    FlightLength = table.Column<double>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PassportNum = table.Column<string>(nullable: false),
                    FlightId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TicketId",
                table: "Rating",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Ticket_TicketId",
                table: "Rating",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Ticket_TicketId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Rating_TicketId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Rating");
        }
    }
}
