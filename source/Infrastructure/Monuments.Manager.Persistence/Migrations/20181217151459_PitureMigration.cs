using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monuments.Manager.Persistence.Migrations
{
    public partial class PitureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Pictures",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Original",
                table: "Pictures",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "Pictures",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Original",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "Pictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Pictures",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
