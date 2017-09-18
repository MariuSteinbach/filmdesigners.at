using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class Awards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Job_JobID",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "JobID",
                table: "Enrollment",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_JobID",
                table: "Enrollment",
                newName: "IX_Enrollment_JobId");

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    AwardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.AwardID);
                    table.ForeignKey(
                        name: "FK_Award_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Award_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Award_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_JobID",
                table: "Award",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Award_MemberID",
                table: "Award",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Award_ProjectID",
                table: "Award",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Job_JobId",
                table: "Enrollment",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Job_JobId",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Enrollment",
                newName: "JobID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_JobId",
                table: "Enrollment",
                newName: "IX_Enrollment_JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Job_JobID",
                table: "Enrollment",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
