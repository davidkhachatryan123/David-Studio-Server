using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class UniqueIndexesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3Ulzjmp0BEqfFdMVWLeT4Cwjbwm5droQwfnaUt1RUe1RRNlDvlke7RZaJt2u1P+fWx6pYN0RJPQATyVawd+nCg==", "qCPHaoomeuz4mfJsa1vB9g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Role",
                table: "UserRoles",
                column: "Role",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_Role",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "7gM4JDBOD1RfxcFK1xQueIhCINMI+TSym6Cnc+8Lx5uxW7CnOuNmb3T+N9ERVwNyf2iUv8ZM48SKrvukBPS4XA==", "5+s3Cy+4Aw1iP+UEfFx9YQ==" });
        }
    }
}
