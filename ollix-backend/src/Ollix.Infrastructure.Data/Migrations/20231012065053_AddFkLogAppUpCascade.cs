using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ollix.Infrastructure.Data.Migrations
{
    public partial class AddFkLogAppUpCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp");

            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp");

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp",
                column: "ClientId",
                principalTable: "ClientApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp",
                column: "UserId",
                principalTable: "UserApp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp");

            migrationBuilder.DropForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp");

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_ClientApp_ClientId",
                table: "LogApp",
                column: "ClientId",
                principalTable: "ClientApp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogApp_UserApp_UserId",
                table: "LogApp",
                column: "UserId",
                principalTable: "UserApp",
                principalColumn: "Id");
        }
    }
}
