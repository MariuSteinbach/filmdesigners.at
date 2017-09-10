using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace filmdesigners.at.Data.Migrations
{
    public partial class MemberAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Activities",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deathday",
                table: "Member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Galleries",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternationalExperiences",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Male",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherContact",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paused",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Resigned",
                table: "Member",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZIP",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Activities",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Deathday",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Galleries",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "InternationalExperiences",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Male",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "OtherContact",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Paused",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Resigned",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "Member");
        }
    }
}
