using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class ProjectUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Countries",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Production",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regiesseur",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Countries",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Production",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Regiesseur",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Project",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
