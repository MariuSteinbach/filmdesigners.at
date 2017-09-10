using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class JobDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_JobID",
                table: "Enrollment",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Job_JobID",
                table: "Enrollment",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Job_JobID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_JobID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Job");
        }
    }
}
