using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class PasswordNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "yY4+k3fnclUrUA8ysvvdyAuKGKeO83FssRuLKzchPTXVSAdkDUlUjeg35KNLgji8BIN2rmYmI41lj1nt0xIvMQ==", "75BpWiwIYziitmZ3WyndvA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3Ulzjmp0BEqfFdMVWLeT4Cwjbwm5droQwfnaUt1RUe1RRNlDvlke7RZaJt2u1P+fWx6pYN0RJPQATyVawd+nCg==", "qCPHaoomeuz4mfJsa1vB9g==" });
        }
    }
}
