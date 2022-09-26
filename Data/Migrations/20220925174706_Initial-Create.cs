using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthoredTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoredTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoredTabs_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritedTabs_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedTabs_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PracticeRoutines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPracticed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeRoutines_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuitarTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    FileLocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFavorites = table.Column<int>(type: "int", nullable: false),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: false),
                    AuthoredTabsId = table.Column<int>(type: "int", nullable: true),
                    FavoritedTabsId = table.Column<int>(type: "int", nullable: true),
                    LikedTabsId = table.Column<int>(type: "int", nullable: true),
                    PracticeRoutineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuitarTabs_AuthoredTabs_AuthoredTabsId",
                        column: x => x.AuthoredTabsId,
                        principalTable: "AuthoredTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GuitarTabs_FavoritedTabs_FavoritedTabsId",
                        column: x => x.FavoritedTabsId,
                        principalTable: "FavoritedTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GuitarTabs_LikedTabs_LikedTabsId",
                        column: x => x.LikedTabsId,
                        principalTable: "LikedTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineId",
                        column: x => x.PracticeRoutineId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    FileLocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFavorites = table.Column<int>(type: "int", nullable: false),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: false),
                    PracticeRoutineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_PracticeRoutines_PracticeRoutineId",
                        column: x => x.PracticeRoutineId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    PracticeRoutineId = table.Column<int>(type: "int", nullable: true),
                    TabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_GuitarTabs_TabId",
                        column: x => x.TabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_PracticeRoutines_PracticeRoutineId",
                        column: x => x.PracticeRoutineId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoredTabs_AppUserId",
                table: "AuthoredTabs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedTabs_AppUserId",
                table: "FavoritedTabs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_AuthoredTabsId",
                table: "GuitarTabs",
                column: "AuthoredTabsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_FavoritedTabsId",
                table: "GuitarTabs",
                column: "FavoritedTabsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_LikedTabsId",
                table: "GuitarTabs",
                column: "LikedTabsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_PracticeRoutineId",
                table: "GuitarTabs",
                column: "PracticeRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_PracticeRoutineId",
                table: "Lessons",
                column: "PracticeRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTabs_AppUserId",
                table: "LikedTabs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeRoutines_AppUserId",
                table: "PracticeRoutines",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LessonId",
                table: "Tags",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PracticeRoutineId",
                table: "Tags",
                column: "PracticeRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TabId",
                table: "Tags",
                column: "TabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "GuitarTabs");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "AuthoredTabs");

            migrationBuilder.DropTable(
                name: "FavoritedTabs");

            migrationBuilder.DropTable(
                name: "LikedTabs");

            migrationBuilder.DropTable(
                name: "PracticeRoutines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
