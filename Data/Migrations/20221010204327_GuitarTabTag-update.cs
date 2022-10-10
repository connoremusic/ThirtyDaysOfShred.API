using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class GuitarTabTagupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuitarTabTags",
                table: "GuitarTabTags");

            migrationBuilder.DropIndex(
                name: "IX_GuitarTabTags_GuitarTabId",
                table: "GuitarTabTags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GuitarTabTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "GuitarTabTags",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuitarTabTags",
                table: "GuitarTabTags",
                columns: new[] { "GuitarTabId", "TagName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuitarTabTags",
                table: "GuitarTabTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "GuitarTabTags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GuitarTabTags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuitarTabTags",
                table: "GuitarTabTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabTags_GuitarTabId",
                table: "GuitarTabTags",
                column: "GuitarTabId");
        }
    }
}
