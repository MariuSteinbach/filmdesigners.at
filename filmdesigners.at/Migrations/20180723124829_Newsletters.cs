using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Migrations
{
    public partial class Newsletters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsletterID",
                table: "Member",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsletterID",
                table: "Job",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    NewsletterID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.NewsletterID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_NewsletterID",
                table: "Member",
                column: "NewsletterID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_NewsletterID",
                table: "Job",
                column: "NewsletterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Newsletter_NewsletterID",
                table: "Job",
                column: "NewsletterID",
                principalTable: "Newsletter",
                principalColumn: "NewsletterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Newsletter_NewsletterID",
                table: "Member",
                column: "NewsletterID",
                principalTable: "Newsletter",
                principalColumn: "NewsletterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Newsletter_NewsletterID",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Newsletter_NewsletterID",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropIndex(
                name: "IX_Member_NewsletterID",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Job_NewsletterID",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "NewsletterID",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "NewsletterID",
                table: "Job");
        }
    }
}
