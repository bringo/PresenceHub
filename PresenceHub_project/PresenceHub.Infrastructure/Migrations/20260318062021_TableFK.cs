using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresenceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_User_UserId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_RecordedBy",
                table: "Attendances",
                column: "RecordedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_User_RecordedBy",
                table: "Attendances",
                column: "RecordedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_User_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_User_UserId1",
                table: "Attendances",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_User_RecordedBy",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_User_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_User_UserId1",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_RecordedBy",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Attendances");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_User_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
