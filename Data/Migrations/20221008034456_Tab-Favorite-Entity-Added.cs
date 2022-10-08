using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class TabFavoriteEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabs_Users_AppUserId",
                table: "GuitarTabs");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeRoutineTags_PracticeRoutines_PracticeRoutineId",
                table: "PracticeRoutineTags");

            migrationBuilder.DropIndex(
                name: "IX_GuitarTabs_AppUserId",
                table: "GuitarTabs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "GuitarTabs");

            migrationBuilder.AlterColumn<int>(
                name: "PracticeRoutineId",
                table: "PracticeRoutineTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteGuitarTabs",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    GuitarTabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteGuitarTabs", x => new { x.AppUserId, x.GuitarTabId });
                    table.ForeignKey(
                        name: "FK_FavoriteGuitarTabs_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteGuitarTabs_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteGuitarTabs_GuitarTabId",
                table: "FavoriteGuitarTabs",
                column: "GuitarTabId");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeRoutineTags_PracticeRoutines_PracticeRoutineId",
                table: "PracticeRoutineTags",
                column: "PracticeRoutineId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeRoutineTags_PracticeRoutines_PracticeRoutineId",
                table: "PracticeRoutineTags");

            migrationBuilder.DropTable(
                name: "FavoriteGuitarTabs");

            migrationBuilder.AlterColumn<int>(
                name: "PracticeRoutineId",
                table: "PracticeRoutineTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeRoutineTags_PracticeRoutines_PracticeRoutineId",
                table: "PracticeRoutineTags",
                column: "PracticeRoutineId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");
        }
    }
}
