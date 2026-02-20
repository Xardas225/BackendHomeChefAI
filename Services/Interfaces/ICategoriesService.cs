using WebAPI.Models.Dish.Categories;

namespace WebAPI.Services.Interfaces;

public interface ICategoriesService
{
    public Task<List<CategoryDto>> GetAllCategoriesAsync();
}
