using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class AddedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "VARCHAR(256)",
                maxLength: 256,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "VARCHAR(512)",
                oldMaxLength: 512)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "VARCHAR(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Role" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Salt", "UserGroupId" },
                values: new object[] { 1, "admin", "F/B90B3N67iXfVyq7PMASMITXZ0A0BvZvw4yjVRAviB18L8S4AP5oXRnaMjDIqxWTXPWlPudqIw8Oo/f7P3WAQ==", "KxwIM++7ItIVOBjb/i9tFA==", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "VARCHAR(512)",
                maxLength: 512,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "VARCHAR(256)",
                oldMaxLength: 256)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");
        }
    }
}
