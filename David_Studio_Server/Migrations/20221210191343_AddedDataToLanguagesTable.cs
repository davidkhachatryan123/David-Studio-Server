using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class AddedDataToLanguagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[] { 1, "en_US", "English (US)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[] { 2, "ru_RU", "Russian (RU)" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[] { 3, "hy_AM", "Armenian (AM)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
