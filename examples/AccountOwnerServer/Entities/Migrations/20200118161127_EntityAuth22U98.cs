using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class EntityAuth22U98 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EA_Roles_EA_Roles_RoleId",
                table: "EA_Roles");

            migrationBuilder.DropIndex(
                name: "IX_EA_Roles_RoleId",
                table: "EA_Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "EA_Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "EA_Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EA_Roles_RoleId",
                table: "EA_Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EA_Roles_EA_Roles_RoleId",
                table: "EA_Roles",
                column: "RoleId",
                principalTable: "EA_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
