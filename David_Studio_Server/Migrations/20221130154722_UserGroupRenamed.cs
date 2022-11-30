using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class UserGroupRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserGroups_UserGroupId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "Users",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                newName: "IX_Users_UserRoleId");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Role" },
                values: new object[] { 1, "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "7gM4JDBOD1RfxcFK1xQueIhCINMI+TSym6Cnc+8Lx5uxW7CnOuNmb3T+N9ERVwNyf2iUv8ZM48SKrvukBPS4XA==", "5+s3Cy+4Aw1iP+UEfFx9YQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "Users",
                newName: "UserGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                newName: "IX_Users_UserGroupId");

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Role" },
                values: new object[] { 1, "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "F/B90B3N67iXfVyq7PMASMITXZ0A0BvZvw4yjVRAviB18L8S4AP5oXRnaMjDIqxWTXPWlPudqIw8Oo/f7P3WAQ==", "KxwIM++7ItIVOBjb/i9tFA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserGroups_UserGroupId",
                table: "Users",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
