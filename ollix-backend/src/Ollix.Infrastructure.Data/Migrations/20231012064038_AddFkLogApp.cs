using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ollix.Infrastructure.Data.Migrations
{
    public partial class AddFkLogApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LogApp_ClientId",
                table: "LogApp",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LogApp_UserId",
                table: "LogApp",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp",
                column: "ClientId",
                principalTable: "ClientApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp",
                column: "UserId",
                principalTable: "UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp");

            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp");

            migrationBuilder.DropIndex(
                name: "IX_LogApp_ClientId",
                table: "LogApp");

            migrationBuilder.DropIndex(
                name: "IX_LogApp_UserId",
                table: "LogApp");
        }
    }
}
