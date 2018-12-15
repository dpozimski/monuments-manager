using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monuments.Manager.Persistence.Migrations
{
    public partial class PictureDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Pictures",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pictures",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pictures");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Pictures",
                type: "image",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2147483647);
        }
    }
}
