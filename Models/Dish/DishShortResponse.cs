using WebAPI.Models.Dish.Ingredient;

namespace WebAPI.Models.Dish;

public class DishShortResponse
{
    public int Id { get; set; }

    // Название блюда
    public string Name { get; set; }

    // Описание блюда
    public string Description { get; set; }

    // Категория блюда (суп, паста и т.п.)
    // TODO: Добавить Enum
    public string Category { get; set; }

    // Цена 
    public int Price { get; set; }

    // Тип кухни (Европейская, Российская и т.п.) 
    // TODO: Добавить Enum
    public string Kitchen { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CookTime { get; set; }

}
