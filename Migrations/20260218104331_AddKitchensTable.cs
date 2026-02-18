using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddKitchensTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitchens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.InsertData(
                table: "kitchens",
                columns: new[] { "Name", "Value" },
                values: new object[,]
                {
                    { "Итальянская", "italian" },
                    { "Японская", "japanese" },
                    { "Китайская", "chinese" },
                    { "Тайская", "thai" },
                    { "Индийская", "indian" },
                    { "Французская", "french" },
                    { "Мексиканская", "mexican" },
                    { "Испанская", "spanish" },
                    { "Греческая", "greek" },
                    { "Турецкая", "turkish" },
                    { "Американская", "american" },
                    { "Русская", "russian" },
                    { "Украинская", "ukrainian" },
                    { "Грузинская", "georgian" },
                    { "Вьетнамская", "vietnamese" },
                    { "Корейская", "korean" },
                    { "Немецкая", "german" },
                    { "Британская", "british" },
                    { "Марокканская", "moroccan" },
                    { "Бразильская", "brazilian" },
                    { "Аргентинская", "argentinian" },
                    { "Перуанская", "peruvian" },
                    { "Шведская", "swedish" },
                    { "Чешская", "czech" },
                    { "Польская", "polish" },
                    { "Узбекская", "uzbek" },
                    { "Армянская", "armenian" },
                    { "Азербайджанская", "azerbaijani" },
                    { "Ливанская", "lebanese" },
                    { "Израильская", "israeli" },
                    { "Индонезийская", "indonesian" },
                    { "Малайзийская", "malaysian" },
                    { "Египетская", "egyptian" },
                    { "Австралийская", "australian" },
                    { "Канадская", "canadian" },
                    { "Португальская", "portuguese" },
                    { "Венгерская", "hungarian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitchens");
        }
    }
}
