using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class UserPassport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasportNumber",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasportNumber",
                table: "Users");
        }
    }
}
