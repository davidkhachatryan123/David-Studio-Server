using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class AddedDataToServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Services_GroupName",
                table: "Services",
                column: "GroupName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_GroupName",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ImgId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
