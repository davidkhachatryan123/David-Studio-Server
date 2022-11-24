using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class FillHomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TemplateTranslations",
                type: "VARCHAR(64)",
                maxLength: 64,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TemplateTranslations",
                type: "VARCHAR(256)",
                maxLength: 256,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[,]
                {
                    { 1, "hy-AM", "Armenian" },
                    { 2, "ru-RU", "Russian" },
                    { 3, "en-US", "English (US)" }
                });

            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, "web" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImgUrl", "PathId" },
                values: new object[] { 1, "uploads/images/web_dev.jpg", 1 });

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "Description", "JumbotronId", "LanguageId", "ServiceId", "Title" },
                values: new object[] { 1, "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:", null, 1, 1, "<strong>| WEB</strong> Կայքերի պատրաստում" });

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "Description", "JumbotronId", "LanguageId", "ServiceId", "Title" },
                values: new object[] { 2, "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.", null, 2, 1, "<strong>|</strong> ПОДГОТОВКА <strong>Веб</strong> САЙТОВ" });

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "Description", "JumbotronId", "LanguageId", "ServiceId", "Title" },
                values: new object[] { 3, "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.", null, 3, 1, "<strong>|</strong> PREPARATION OF <strong>WEBSITES</strong>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TemplateTranslations",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "VARCHAR(64)",
                oldMaxLength: 64)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TemplateTranslations",
                type: "longtext",
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
