using WebAPI.Models.Dish.Categories;

namespace WebAPI.Repositories.Interfaces;

public interface ICategoriesRepository
{

    public Task<List<CategoryEntity>> GetCategoryEntitiesAsync();

}
