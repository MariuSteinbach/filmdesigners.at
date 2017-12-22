using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Member_JobId",
                table: "Member",
                column: "JobId");
            /*
            migrationBuilder.AddForeignKey(
                name: "FK_Member_Job_JobId",
                table: "Member",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Job_JobId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_JobId",
                table: "Member");
        }
    }
}
