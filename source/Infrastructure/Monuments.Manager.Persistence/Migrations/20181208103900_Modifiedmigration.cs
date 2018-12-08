using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monuments.Manager.Persistence.Migrations
{
    public partial class Modifiedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoggedIn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Streets",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Streets",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Provinces",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Provinces",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pictures",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Pictures",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Monuments",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Monuments",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Districts",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Districts",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Communes",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Communes",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cities",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Cities",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Addresses",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Addresses",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_ModifiedBy",
                table: "Users",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StreetEntity_CreatedBy",
                table: "Streets",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StreetEntity_ModifiedBy",
                table: "Streets",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceEntity_CreatedBy",
                table: "Provinces",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceEntity_ModifiedBy",
                table: "Provinces",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PictureEntity_CreatedBy",
                table: "Pictures",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PictureEntity_ModifiedBy",
                table: "Pictures",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MonumentEntity_CreatedBy",
                table: "Monuments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MonumentEntity_ModifiedBy",
                table: "Monuments",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictEntity_CreatedBy",
                table: "Districts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictEntity_ModifiedBy",
                table: "Districts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneEntity_CreatedBy",
                table: "Communes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneEntity_ModifiedBy",
                table: "Communes",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CityEntity_CreatedBy",
                table: "Cities",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CityEntity_ModifiedBy",
                table: "Cities",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_CreatedBy",
                table: "Addresses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_ModifiedBy",
                table: "Addresses",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserEntity_CreatedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserEntity_ModifiedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StreetEntity_CreatedBy",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_StreetEntity_ModifiedBy",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_ProvinceEntity_CreatedBy",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_ProvinceEntity_ModifiedBy",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_PictureEntity_CreatedBy",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_PictureEntity_ModifiedBy",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_MonumentEntity_CreatedBy",
                table: "Monuments");

            migrationBuilder.DropIndex(
                name: "IX_MonumentEntity_ModifiedBy",
                table: "Monuments");

            migrationBuilder.DropIndex(
                name: "IX_DistrictEntity_CreatedBy",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_DistrictEntity_ModifiedBy",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_CommuneEntity_CreatedBy",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_CommuneEntity_ModifiedBy",
                table: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_CityEntity_CreatedBy",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_CityEntity_ModifiedBy",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_CreatedBy",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_ModifiedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLoggedIn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Monuments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Monuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Communes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Addresses");
        }
    }
}
