using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class JobModelID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Job_JobId",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_JobId",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Enrollment",
                newName: "JobID");

            migrationBuilder.AlterColumn<int>(
                name: "JobID",
                table: "Enrollment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobID",
                table: "Enrollment",
                newName: "JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Enrollment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_JobId",
                table: "Enrollment",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Job_JobId",
                table: "Enrollment",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
