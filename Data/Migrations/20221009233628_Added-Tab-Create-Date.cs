﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    public partial class AddedTabCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "GuitarTabs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "GuitarTabs");
        }
    }
}
