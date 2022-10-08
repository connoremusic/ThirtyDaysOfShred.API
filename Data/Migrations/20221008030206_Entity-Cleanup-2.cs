using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class EntityCleanup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineDtoId",
                table: "GuitarTabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_PracticeRoutines_PracticeRoutineDtoId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "GuitarTabs");

            migrationBuilder.RenameColumn(
                name: "PracticeRoutineDtoId",
                table: "Lessons",
                newName: "PracticeRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_PracticeRoutineDtoId",
                table: "Lessons",
                newName: "IX_Lessons_PracticeRoutineId");

            migrationBuilder.RenameColumn(
                name: "PracticeRoutineDtoId",
                table: "GuitarTabs",
                newName: "PracticeRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_GuitarTabs_PracticeRoutineDtoId",
                table: "GuitarTabs",
                newName: "IX_GuitarTabs_PracticeRoutineId");

            migrationBuilder.CreateTable(
                name: "GuitarTabTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTabTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuitarTabTags_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonTags_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracticeRoutineTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeRoutineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeRoutineTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeRoutineTags_PracticeRoutines_PracticeRoutineId",
                        column: x => x.PracticeRoutineId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabTags_GuitarTabId",
                table: "GuitarTabTags",
                column: "GuitarTabId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTags_LessonId",
                table: "LessonTags",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeRoutineTags_PracticeRoutineId",
                table: "PracticeRoutineTags",
                column: "PracticeRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineId",
                table: "GuitarTabs",
                column: "PracticeRoutineId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_PracticeRoutines_PracticeRoutineId",
                table: "Lessons",
                column: "PracticeRoutineId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineId",
                table: "GuitarTabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_PracticeRoutines_PracticeRoutineId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "GuitarTabTags");

            migrationBuilder.DropTable(
                name: "LessonTags");

            migrationBuilder.DropTable(
                name: "PracticeRoutineTags");

            migrationBuilder.RenameColumn(
                name: "PracticeRoutineId",
                table: "Lessons",
                newName: "PracticeRoutineDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_PracticeRoutineId",
                table: "Lessons",
                newName: "IX_Lessons_PracticeRoutineDtoId");

            migrationBuilder.RenameColumn(
                name: "PracticeRoutineId",
                table: "GuitarTabs",
                newName: "PracticeRoutineDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_GuitarTabs_PracticeRoutineId",
                table: "GuitarTabs",
                newName: "IX_GuitarTabs_PracticeRoutineDtoId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "GuitarTabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    PracticeRoutineDtoId = table.Column<int>(type: "int", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_PracticeRoutines_PracticeRoutineDtoId",
                        column: x => x.PracticeRoutineDtoId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_GuitarTabId",
                table: "Tags",
                column: "GuitarTabId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LessonId",
                table: "Tags",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PracticeRoutineDtoId",
                table: "Tags",
                column: "PracticeRoutineDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineDtoId",
                table: "GuitarTabs",
                column: "PracticeRoutineDtoId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_PracticeRoutines_PracticeRoutineDtoId",
                table: "Lessons",
                column: "PracticeRoutineDtoId",
                principalTable: "PracticeRoutines",
                principalColumn: "Id");
        }
    }
}
