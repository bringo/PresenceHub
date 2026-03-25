using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresenceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UPdateDbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_User_UserId1",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "DOB",
                table: "UserDetails",
                newName: "Dob");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "UserDetails",
                newName: "DOB");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_User_UserId1",
                table: "Attendances",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
