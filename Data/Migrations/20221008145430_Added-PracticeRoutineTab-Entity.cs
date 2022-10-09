using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class AddedPracticeRoutineTabEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineId",
                table: "GuitarTabs");

            migrationBuilder.DropIndex(
                name: "IX_GuitarTabs_PracticeRoutineId",
                table: "GuitarTabs");

            migrationBuilder.DropColumn(
                name: "PracticeRoutineId",
                table: "GuitarTabs");

            migrationBuilder.CreateTable(
                name: "PracticeRoutinesTabs",
                columns: table => new
                {
                    PracticeRoutineId = table.Column<int>(type: "int", nullable: false),
                    GuitarTabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeRoutinesTabs", x => new { x.PracticeRoutineId, x.GuitarTabId });
                    table.ForeignKey(
                        name: "FK_PracticeRoutinesTabs_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracticeRoutinesTabs_PracticeRoutines_PracticeRoutineId",
                        column: x => x.PracticeRoutineId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PracticeRoutinesTabs_GuitarTabId",
                table: "PracticeRoutinesTabs",
                column: "GuitarTabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracticeRoutinesTabs");

            migrationBuilder.AddColumn<int>(
                name: "PracticeRoutineId",
                table: "GuitarTabs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_PracticeRoutineId",
                table: "GuitarTabs",
                column: "PracticeRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineId",
                table: "GuitarTabs",
                column: "PracticeRoutineId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");
        }
    }
}
