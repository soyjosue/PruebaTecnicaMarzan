using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnicaMarzan.Data.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Accounts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
