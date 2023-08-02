using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactCheck84.Migrations
{
    /// <inheritdoc />
    public partial class CensorChiefRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CensorChiefRolesId",
                table: "CensorChiefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CensorChiefRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManageUsers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManageWords = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CensorChiefRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CensorChiefs_CensorChiefRolesId",
                table: "CensorChiefs",
                column: "CensorChiefRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CensorChiefs_CensorChiefRoles_CensorChiefRolesId",
                table: "CensorChiefs",
                column: "CensorChiefRolesId",
                principalTable: "CensorChiefRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CensorChiefs_CensorChiefRoles_CensorChiefRolesId",
                table: "CensorChiefs");

            migrationBuilder.DropTable(
                name: "CensorChiefRoles");

            migrationBuilder.DropIndex(
                name: "IX_CensorChiefs_CensorChiefRolesId",
                table: "CensorChiefs");

            migrationBuilder.DropColumn(
                name: "CensorChiefRolesId",
                table: "CensorChiefs");
        }
    }
}
