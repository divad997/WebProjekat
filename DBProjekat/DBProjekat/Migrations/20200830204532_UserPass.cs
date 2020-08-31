using Microsoft.EntityFrameworkCore.Migrations;

namespace DBProjekat.Migrations
{
    public partial class UserPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasportNumber",
                table: "Users",
                newName: "PassportNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PassportNum",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Users",
                newName: "PasportNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNum",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
