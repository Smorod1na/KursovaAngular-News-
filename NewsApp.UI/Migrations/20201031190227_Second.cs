using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApp.UI.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataRegister",
                table: "UserAdditional",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublishCount",
                table: "UserAdditional",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "UserAdditional",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegister",
                table: "UserAdditional");

            migrationBuilder.DropColumn(
                name: "PublishCount",
                table: "UserAdditional");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "UserAdditional");
        }
    }
}
