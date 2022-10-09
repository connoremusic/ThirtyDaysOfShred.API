using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class FullyDefinedTagRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabTags_GuitarTabs_GuitarTabId",
                table: "GuitarTabTags");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTags_Lessons_LessonId",
                table: "LessonTags");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "LessonTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuitarTabId",
                table: "GuitarTabTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabTags_GuitarTabs_GuitarTabId",
                table: "GuitarTabTags",
                column: "GuitarTabId",
                principalTable: "GuitarTabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTags_Lessons_LessonId",
                table: "LessonTags",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarTabTags_GuitarTabs_GuitarTabId",
                table: "GuitarTabTags");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTags_Lessons_LessonId",
                table: "LessonTags");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "LessonTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GuitarTabId",
                table: "GuitarTabTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarTabTags_GuitarTabs_GuitarTabId",
                table: "GuitarTabTags",
                column: "GuitarTabId",
                principalTable: "GuitarTabs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTags_Lessons_LessonId",
                table: "LessonTags",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }
    }
}
