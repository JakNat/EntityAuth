using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyApp.Infrastructure.Migrations
{
    public partial class EnityAuthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EA_Resource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EA_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EA_Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EA_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EA_Permissions_EA_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "EA_Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EA_Permissions_EA_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EA_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EA_Permissions_ResourceId",
                table: "EA_Permissions",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EA_Permissions_RoleId",
                table: "EA_Permissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EA_Permissions");

            migrationBuilder.DropTable(
                name: "EA_Resource");

            migrationBuilder.DropTable(
                name: "EA_Roles");
        }
    }
}
