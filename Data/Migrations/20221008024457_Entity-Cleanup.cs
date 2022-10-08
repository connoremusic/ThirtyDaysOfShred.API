using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class EntityCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoredTab");

            migrationBuilder.DropTable(
                name: "FavoritedTab");

            migrationBuilder.DropTable(
                name: "LikedTab");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "GuitarTabs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_AppUserId",
                table: "GuitarTabs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabs_Users_AppUserId",
                table: "GuitarTabs",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabs_Users_AppUserId",
                table: "GuitarTabs");

            migrationBuilder.DropIndex(
                name: "IX_GuitarTabs_AppUserId",
                table: "GuitarTabs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "GuitarTabs");

            migrationBuilder.CreateTable(
                name: "AuthoredTab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoredTab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoredTab_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthoredTab_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedTab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedTab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritedTab_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoritedTab_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedTab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedTab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedTab_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikedTab_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoredTab_AppUserId",
                table: "AuthoredTab",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoredTab_GuitarTabId",
                table: "AuthoredTab",
                column: "GuitarTabId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedTab_AppUserId",
                table: "FavoritedTab",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedTab_GuitarTabId",
                table: "FavoritedTab",
                column: "GuitarTabId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTab_AppUserId",
                table: "LikedTab",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTab_GuitarTabId",
                table: "LikedTab",
                column: "GuitarTabId");
        }
    }
}
