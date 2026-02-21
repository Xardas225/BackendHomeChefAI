using WebAPI.Models.Dish;

namespace WebAPI.Services.Interfaces;

public interface IDishesService
{
    public Task<List<DishResponse>> GetAllDishesAsync(DishFilters? filters, string? sort);

    public Task<int> CreateDishAsync(DishRequest request);

    public Task<DishResponse> GetDishByIdAsync(int id);

    public Task<List<DishShortResponse>> GetAllDishesByAuthorId(int id);
}
