using Microsoft.EntityFrameworkCore.Migrations;

namespace Monuments.Manager.Persistence.Migrations
{
    public partial class UserEmailIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "Users",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "Users");
        }
    }
}
