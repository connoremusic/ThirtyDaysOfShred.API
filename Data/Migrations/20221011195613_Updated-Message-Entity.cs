using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class UpdatedMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderDelete",
                table: "Messages",
                newName: "SenderDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderDeleted",
                table: "Messages",
                newName: "SenderDelete");
        }
    }
}
