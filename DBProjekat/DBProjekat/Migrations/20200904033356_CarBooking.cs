using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class CarBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_RentCompanies_RentCompanyId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Car_CarId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "Car1",
                table: "Cars",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_Car_RentCompanyId",
                table: "Cars",
                newName: "IX_Cars_RentCompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "RentCompanyId",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "DailyRate",
                table: "Cars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarBookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: false),
                    ReserveStart = table.Column<DateTime>(nullable: false),
                    ReserveEnd = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    RentCompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarBookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookings_RentCompanies_RentCompanyId",
                        column: x => x.RentCompanyId,
                        principalTable: "RentCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_CarId",
                table: "CarBookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_RentCompanyId",
                table: "CarBookings",
                column: "RentCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RentCompanies_RentCompanyId",
                table: "Cars",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Cars_CarId",
                table: "Rating",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RentCompanies_RentCompanyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Cars_CarId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "CarBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DailyRate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Car",
                newName: "Car1");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_RentCompanyId",
                table: "Car",
                newName: "IX_Car_RentCompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "RentCompanyId",
                table: "Car",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_RentCompanies_RentCompanyId",
                table: "Car",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Car_CarId",
                table: "Rating",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
