using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class RentCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Rating",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentCompanyId",
                table: "Rating",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RentCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Prices = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Car1 = table.Column<string>(nullable: false),
                    RentCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_RentCompanies_RentCompanyId",
                        column: x => x.RentCompanyId,
                        principalTable: "RentCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location1 = table.Column<string>(nullable: false),
                    RentCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_RentCompanies_RentCompanyId",
                        column: x => x.RentCompanyId,
                        principalTable: "RentCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CarId",
                table: "Rating",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RentCompanyId",
                table: "Rating",
                column: "RentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentCompanyId",
                table: "Car",
                column: "RentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RentCompanyId",
                table: "Location",
                column: "RentCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Car_CarId",
                table: "Rating",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_RentCompanies_RentCompanyId",
                table: "Rating",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Car_CarId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_RentCompanies_RentCompanyId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RentCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Rating_CarId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_RentCompanyId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "RentCompanyId",
                table: "Rating");
        }
    }
}
