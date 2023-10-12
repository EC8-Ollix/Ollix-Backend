using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ollix.Infrastructure.Data.Migrations
{
    public partial class AttRefClienteToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserApp_ClientId",
                table: "UserApp",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApp_ClientApp_ClientId",
                table: "UserApp",
                column: "ClientId",
                principalTable: "ClientApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApp_ClientApp_ClientId",
                table: "UserApp");

            migrationBuilder.DropIndex(
                name: "IX_UserApp_ClientId",
                table: "UserApp");
        }
    }
}
