using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeUserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taskeds_AspNetUsers_UserId",
                table: "taskeds");

            migrationBuilder.DropIndex(
                name: "IX_taskeds_UserId",
                table: "taskeds");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "taskeds",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "taskeds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_taskeds_UserId1",
                table: "taskeds",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_taskeds_AspNetUsers_UserId1",
                table: "taskeds",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taskeds_AspNetUsers_UserId1",
                table: "taskeds");

            migrationBuilder.DropIndex(
                name: "IX_taskeds_UserId1",
                table: "taskeds");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "taskeds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "taskeds",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_taskeds_UserId",
                table: "taskeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_taskeds_AspNetUsers_UserId",
                table: "taskeds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
