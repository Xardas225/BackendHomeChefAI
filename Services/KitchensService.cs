using Microsoft.Extensions.Caching.Distributed;
using WebAPI.Models.Dish.Kitchens;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;
using System.Text.Json;

namespace WebAPI.Services;

public class KitchensService : IKitchensService
{

    private const string kitchensCacheKey = "kitchens";

    private readonly IKitchensRepository _kitchensRepository;
    private readonly IDistributedCache _cache;

    public KitchensService(IKitchensRepository kitchensRepository, IDistributedCache cache)
    {
        _kitchensRepository = kitchensRepository;
        _cache = cache;
    }

    public async Task<List<KitchensDto>> GetAllKitchensAsync()
    {

        var cachedData = await _cache.GetStringAsync(kitchensCacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonSerializer.Deserialize<List<KitchensDto>>(cachedData);
        }

        var kitchens = await _kitchensRepository.GetAllKitchensAsync();

        var response = kitchens.Select(k => new  KitchensDto
        {
            Id = k.Id,
            Name = k.Name,
            Value = k.Value
        }).ToList();


        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromHours(1)
        };

        await _cache.SetStringAsync(kitchensCacheKey, JsonSerializer.Serialize(response), options);

        return response;
    }

}
