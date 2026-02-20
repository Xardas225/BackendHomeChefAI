using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
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
                    table.PrimaryKey("PK_categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { "pizza", "Пицца" },
                    { "burgers", "Бургеры" },
                    { "sushi", "Суши и роллы" },
                    { "asian", "Вок и лапша" },
                    { "soups", "Супы" },
                    { "salads", "Салаты" },
                    { "pasta", "Паста" },
                    { "meat", "Мясные блюда" },
                    { "fish", "Рыба и морепродукты" },
                    { "bbq", "Гриль и BBQ" },
                    { "breakfast", "Завтраки" },
                    { "desserts", "Десерты" },
                    { "pastry", "Выпечка" },
                    { "bread", "Хлеб и лепёшки" },
                    { "drinks", "Напитки" },
                    { "hot", "Горячие напитки" },
                    { "alcohol", "Алкоголь" },
                    { "snacks", "Закуски" },
                    { "sauces", "Соусы" },
                    { "sidedishes", "Гарниры" },
                    { "wok", "Wok" },
                    { "shawarma", "Шаурма" },
                    { "poke", "Поке" },
                    { "sets", "Сеты и комбо" },
                    { "business", "Бизнес-ланчи" },
                    { "vegetarian", "Вегетарианское" },
                    { "vegan", "Веганское" },
                    { "kids", "Детское меню" },
                    { "diet", "Диетическое" },
                    { "halal", "Халяль" },
                    { "cake", "Торты на заказ" },
                    { "icecream", "Мороженое" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");


            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Value",
                keyValues: new object[]
                {
                    "pizza", "burgers", "sushi", "asian", "soups", "salads", "pasta", "meat", "fish", "bbq",
                    "breakfast", "desserts", "pastry", "bread", "drinks", "hot", "alcohol", "snacks", "sauces",
                    "sidedishes", "wok", "shawarma", "poke", "sets", "business", "vegetarian", "vegan", "kids",
                    "diet", "halal", "cake", "icecream"
                });
        }
    }
}
