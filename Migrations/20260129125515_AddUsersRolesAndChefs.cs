using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersRolesAndChefs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChefProfile_users_UserId",
                table: "ChefProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChefProfile",
                table: "ChefProfile");

            migrationBuilder.RenameTable(
                name: "ChefProfile",
                newName: "chefs");

            migrationBuilder.RenameIndex(
                name: "IX_ChefProfile_UserId",
                table: "chefs",
                newName: "IX_chefs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chefs",
                table: "chefs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_chefs_users_UserId",
                table: "chefs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chefs_users_UserId",
                table: "chefs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chefs",
                table: "chefs");

            migrationBuilder.RenameTable(
                name: "chefs",
                newName: "ChefProfile");

            migrationBuilder.RenameIndex(
                name: "IX_chefs_UserId",
                table: "ChefProfile",
                newName: "IX_ChefProfile_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChefProfile",
                table: "ChefProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChefProfile_users_UserId",
                table: "ChefProfile",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
