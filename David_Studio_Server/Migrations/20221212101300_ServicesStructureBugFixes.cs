using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class ServicesStructureBugFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Files_FileId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTranslations_HomeServices_HomeServiceId",
                table: "ServiceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTranslations_Translations_DescriptionTranslationId",
                table: "ServiceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTranslations_Translations_TitleTranslationId",
                table: "ServiceTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Services_FileId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTranslations",
                table: "ServiceTranslations");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "ServiceTranslations",
                newName: "HomeServiceTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTranslations_TitleTranslationId",
                table: "HomeServiceTranslations",
                newName: "IX_HomeServiceTranslations_TitleTranslationId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTranslations_HomeServiceId",
                table: "HomeServiceTranslations",
                newName: "IX_HomeServiceTranslations_HomeServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTranslations_DescriptionTranslationId",
                table: "HomeServiceTranslations",
                newName: "IX_HomeServiceTranslations_DescriptionTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeServiceTranslations",
                table: "HomeServiceTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeServiceTranslations_HomeServices_HomeServiceId",
                table: "HomeServiceTranslations",
                column: "HomeServiceId",
                principalTable: "HomeServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeServiceTranslations_Translations_DescriptionTranslationId",
                table: "HomeServiceTranslations",
                column: "DescriptionTranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeServiceTranslations_Translations_TitleTranslationId",
                table: "HomeServiceTranslations",
                column: "TitleTranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeServiceTranslations_HomeServices_HomeServiceId",
                table: "HomeServiceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeServiceTranslations_Translations_DescriptionTranslationId",
                table: "HomeServiceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeServiceTranslations_Translations_TitleTranslationId",
                table: "HomeServiceTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeServiceTranslations",
                table: "HomeServiceTranslations");

            migrationBuilder.RenameTable(
                name: "HomeServiceTranslations",
                newName: "ServiceTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_HomeServiceTranslations_TitleTranslationId",
                table: "ServiceTranslations",
                newName: "IX_ServiceTranslations_TitleTranslationId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeServiceTranslations_HomeServiceId",
                table: "ServiceTranslations",
                newName: "IX_ServiceTranslations_HomeServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeServiceTranslations_DescriptionTranslationId",
                table: "ServiceTranslations",
                newName: "IX_ServiceTranslations_DescriptionTranslationId");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTranslations",
                table: "ServiceTranslations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_FileId",
                table: "Services",
                column: "FileId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTranslations_Translations_DescriptionTranslationId",
                table: "ServiceTranslations",
                column: "DescriptionTranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTranslations_Translations_TitleTranslationId",
                table: "ServiceTranslations",
                column: "TitleTranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
