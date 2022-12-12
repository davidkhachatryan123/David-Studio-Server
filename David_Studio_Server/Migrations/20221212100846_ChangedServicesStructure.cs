using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class ChangedServicesStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Files_ImageId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTranslations_Services_ServiceId",
                table: "ServiceTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ButtonColor",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Href",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServiceTranslations",
                newName: "HomeServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTranslations_ServiceId",
                table: "ServiceTranslations",
                newName: "IX_ServiceTranslations_HomeServiceId");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Services",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Services_GroupName",
                table: "Services",
                newName: "IX_Services_Name");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ButtonColor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Path = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeServices_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "FileId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Web" },
                    { 2, null, "Desktop" },
                    { 3, null, "Arduino" },
                    { 4, null, "Hosting" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_FileId",
                table: "Services",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_ImageId",
                table: "HomeServices",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_ServiceId",
                table: "HomeServices",
                column: "ServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Files_FileId",
                table: "Services",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTranslations_HomeServices_HomeServiceId",
                table: "ServiceTranslations",
                column: "HomeServiceId",
                principalTable: "HomeServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Files_FileId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTranslations_HomeServices_HomeServiceId",
                table: "ServiceTranslations");

            migrationBuilder.DropTable(
                name: "HomeServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_FileId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "HomeServiceId",
                table: "ServiceTranslations",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTranslations_HomeServiceId",
                table: "ServiceTranslations",
                newName: "IX_ServiceTranslations_ServiceId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Services",
                newName: "GroupName");

            migrationBuilder.RenameIndex(
                name: "IX_Services_Name",
                table: "Services",
                newName: "IX_Services_GroupName");

            migrationBuilder.AddColumn<string>(
                name: "ButtonColor",
                table: "Services",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "Href",
                table: "Services",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Files_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTranslations_Services_ServiceId",
                table: "ServiceTranslations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
