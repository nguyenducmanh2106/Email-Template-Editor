using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIG.Core.Framework.Email.Migrations
{
    public partial class addTemplateEmailtable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "EmailTemplates",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JsonDesign",
                table: "EmailTemplates",
                newName: "DisplayMode");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "EmailTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Design",
                table: "EmailTemplates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedByUserId",
                table: "EmailTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOnDate",
                table: "EmailTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "LastModifiedByUserId",
                table: "EmailTemplates");

            migrationBuilder.DropColumn(
                name: "LastModifiedOnDate",
                table: "EmailTemplates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmailTemplates",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DisplayMode",
                table: "EmailTemplates",
                newName: "JsonDesign");
        }
    }
}
