using Microsoft.EntityFrameworkCore.Migrations;

namespace Monuments.Manager.Persistence.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MonumentEntity_FormOfProtection",
                table: "Monuments",
                column: "FormOfProtection");

            migrationBuilder.CreateIndex(
                name: "IX_MonumentEntity_Name",
                table: "Monuments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_Area",
                table: "Addresses",
                column: "Area");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_City",
                table: "Addresses",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_Commune",
                table: "Addresses",
                column: "Commune");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_District",
                table: "Addresses",
                column: "District");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_Province",
                table: "Addresses",
                column: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_Street",
                table: "Addresses",
                column: "Street");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_StreetNumber",
                table: "Addresses",
                column: "StreetNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MonumentEntity_FormOfProtection",
                table: "Monuments");

            migrationBuilder.DropIndex(
                name: "IX_MonumentEntity_Name",
                table: "Monuments");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_Area",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_City",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_Commune",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_District",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_Province",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_Street",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntity_StreetNumber",
                table: "Addresses");
        }
    }
}
