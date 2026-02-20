using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebAPI.Models.Dish.Categories;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class CategoriesService : ICategoriesService
{
    private string categoriesCacheKey = "categories";

    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IDistributedCache _cache;

    public CategoriesService(ICategoriesRepository categoriesRepository, IDistributedCache cache)
    {
        _categoriesRepository = categoriesRepository; 
        _cache = cache;

    }


    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var cachedData = await _cache.GetStringAsync(categoriesCacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonSerializer.Deserialize<List<CategoryDto>>(cachedData);
        }

        var categories = await _categoriesRepository.GetCategoryEntitiesAsync();

        var response = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Value = c.Value
        }
        ).ToList();

        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromHours(1)
        };

        await _cache.SetStringAsync(categoriesCacheKey, JsonSerializer.Serialize(response), options);

        return response;
    }

}
