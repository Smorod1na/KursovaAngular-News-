using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApp.UI.Migrations
{
    public partial class Five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIsFavorites_UserAdditional_UserAdditionalId",
                table: "UserIsFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserIsFavorites_UserAdditionalId",
                table: "UserIsFavorites");

            migrationBuilder.DropColumn(
                name: "UserAdditionalId",
                table: "UserIsFavorites");

            migrationBuilder.AlterColumn<string>(
                name: "NewsId",
                table: "UserIsFavorites",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserIsFavorites",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserIsFavorites_NewsId",
                table: "UserIsFavorites",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIsFavorites_News_NewsId",
                table: "UserIsFavorites",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIsFavorites_News_NewsId",
                table: "UserIsFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserIsFavorites_NewsId",
                table: "UserIsFavorites");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserIsFavorites");

            migrationBuilder.AlterColumn<string>(
                name: "NewsId",
                table: "UserIsFavorites",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdditionalId",
                table: "UserIsFavorites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserIsFavorites_UserAdditionalId",
                table: "UserIsFavorites",
                column: "UserAdditionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIsFavorites_UserAdditional_UserAdditionalId",
                table: "UserIsFavorites",
                column: "UserAdditionalId",
                principalTable: "UserAdditional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
