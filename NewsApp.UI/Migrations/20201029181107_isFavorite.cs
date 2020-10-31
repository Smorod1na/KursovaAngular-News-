using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApp.UI.Migrations
{
    public partial class isFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserAdditional",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserIsFavorites",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NewsId = table.Column<string>(nullable: false),
                    IsFavorite = table.Column<bool>(nullable: false),
                    UserAdditionalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIsFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIsFavorites_UserAdditional_UserAdditionalId",
                        column: x => x.UserAdditionalId,
                        principalTable: "UserAdditional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserIsFavorites_UserAdditionalId",
                table: "UserIsFavorites",
                column: "UserAdditionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIsFavorites");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserAdditional");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "News");
        }
    }
}
