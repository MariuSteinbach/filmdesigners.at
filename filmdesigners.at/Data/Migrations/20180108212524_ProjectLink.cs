using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class ProjectLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Project");
        }
    }
}
