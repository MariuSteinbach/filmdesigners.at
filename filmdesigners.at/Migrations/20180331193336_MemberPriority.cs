using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Migrations
{
    public partial class MemberPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Member");
        }
    }
}
