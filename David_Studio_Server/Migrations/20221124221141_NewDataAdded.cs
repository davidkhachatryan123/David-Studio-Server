using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David_Studio_Server.Migrations
{
    public partial class NewDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, "desktop" });

            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3, "arduino" });

            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "Value" },
                values: new object[] { 4, "hosting" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImgUrl", "PathId" },
                values: new object[] { 2, "uploads/images/desktop_dev.jpg", 2 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImgUrl", "PathId" },
                values: new object[] { 3, "uploads/images/arduino_dev.jpg", 3 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImgUrl", "PathId" },
                values: new object[] { 4, "uploads/images/server_dev.jpg", 4 });

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "Description", "JumbotronId", "LanguageId", "ServiceId", "Title" },
                values: new object[,]
                {
                    { 4, "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:", null, 1, 2, "<strong>| Desktop</strong> Ծրագրերի Պատրաստում" },
                    { 5, "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.", null, 2, 2, "<strong>| Desktop</strong> Приложения" },
                    { 6, "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.", null, 3, 2, "<strong>| Desktop</strong> Programs Preparation" },
                    { 7, "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:", null, 1, 3, "<strong>| ARDUINO</strong> Սալիկների Ծրագրավորում" },
                    { 8, "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.", null, 2, 3, "<strong>| ARDUINO</strong> Программирование" },
                    { 9, "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.", null, 3, 3, "<strong>| ARDUINO</strong> Programming" },
                    { 10, "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:", null, 1, 4, "<strong>| HOSTING</strong> ԵՎ <strong>SERVER</strong>" },
                    { 11, "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.", null, 2, 4, "<strong>| HOSTING</strong> и <strong>SERVER</strong>" },
                    { 12, "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.", null, 3, 4, "<strong>| HOSTING</strong> and <strong>SERVER</strong>" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 12);

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

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
