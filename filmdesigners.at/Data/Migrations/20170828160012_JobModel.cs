using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class JobModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Enrollment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Job_JobId",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_JobId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "Job",
                table: "Enrollment",
                nullable: true);
        }
    }
}
