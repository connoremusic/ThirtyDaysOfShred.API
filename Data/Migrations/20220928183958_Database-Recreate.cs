using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class DatabaseRecreate : Migration
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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Influences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Users_AppUserId",
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
                name: "ProfilePhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePhoto_Users_AppUserId",
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    FileLocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFavorites = table.Column<int>(type: "int", nullable: false),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: false),
                    PracticeRoutineDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuitarTabs_PracticeRoutines_PracticeRoutineDtoId",
                        column: x => x.PracticeRoutineDtoId,
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
                    PracticeRoutineDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_PracticeRoutines_PracticeRoutineDtoId",
                        column: x => x.PracticeRoutineDtoId,
                        principalTable: "PracticeRoutines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthoredTab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
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
                    GuitarTabId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
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
                    GuitarTabId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TabPreviewImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarTabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabPreviewImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabPreviewImage_GuitarTabs_GuitarTabId",
                        column: x => x.GuitarTabId,
                        principalTable: "GuitarTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarTabId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    PracticeRoutineDtoId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Goal_AppUserId",
                table: "Goal",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GuitarTabs_PracticeRoutineDtoId",
                table: "GuitarTabs",
                column: "PracticeRoutineDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_PracticeRoutineDtoId",
                table: "Lessons",
                column: "PracticeRoutineDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTab_AppUserId",
                table: "LikedTab",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTab_GuitarTabId",
                table: "LikedTab",
                column: "GuitarTabId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeRoutines_AppUserId",
                table: "PracticeRoutines",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhoto_AppUserId",
                table: "ProfilePhoto",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TabPreviewImage_GuitarTabId",
                table: "TabPreviewImage",
                column: "GuitarTabId",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoredTab");

            migrationBuilder.DropTable(
                name: "FavoritedTab");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "LikedTab");

            migrationBuilder.DropTable(
                name: "ProfilePhoto");

            migrationBuilder.DropTable(
                name: "TabPreviewImage");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "GuitarTabs");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "PracticeRoutines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
