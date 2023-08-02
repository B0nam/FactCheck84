using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactCheck84.Migrations
{
    /// <inheritdoc />
    public partial class AccountStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CensorChief_User_UserId",
                table: "CensorChief");

            migrationBuilder.DropForeignKey(
                name: "FK_User_AccountStatus_AccountStatusId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CensorChief",
                table: "CensorChief");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "CensorChief",
                newName: "CensorChiefs");

            migrationBuilder.RenameTable(
                name: "AccountStatus",
                newName: "AccountStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_User_AccountStatusId",
                table: "Users",
                newName: "IX_Users_AccountStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CensorChief_UserId",
                table: "CensorChiefs",
                newName: "IX_CensorChiefs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CensorChiefs",
                table: "CensorChiefs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CensorChiefs_Users_UserId",
                table: "CensorChiefs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountStatuses_AccountStatusId",
                table: "Users",
                column: "AccountStatusId",
                principalTable: "AccountStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CensorChiefs_Users_UserId",
                table: "CensorChiefs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountStatuses_AccountStatusId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CensorChiefs",
                table: "CensorChiefs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountStatuses",
                table: "AccountStatuses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "CensorChiefs",
                newName: "CensorChief");

            migrationBuilder.RenameTable(
                name: "AccountStatuses",
                newName: "AccountStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccountStatusId",
                table: "User",
                newName: "IX_User_AccountStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CensorChiefs_UserId",
                table: "CensorChief",
                newName: "IX_CensorChief_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CensorChief",
                table: "CensorChief",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountStatus",
                table: "AccountStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CensorChief_User_UserId",
                table: "CensorChief",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AccountStatus_AccountStatusId",
                table: "User",
                column: "AccountStatusId",
                principalTable: "AccountStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
