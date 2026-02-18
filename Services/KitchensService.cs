using WebAPI.Models.Dish.Kitchens;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class KitchensService : IKitchensService
{

    private readonly IKitchensRepository _kitchensRepository;

    public KitchensService(IKitchensRepository kitchensRepository)
    {
        _kitchensRepository = kitchensRepository;
    }

    public async Task<List<KitchensDto>> GetAllKitchensAsync()
    {
        var kitchens = await _kitchensRepository.GetAllKitchensAsync();

        var response = kitchens.Select(k => new  KitchensDto
        {
            Id = k.Id,
            Name = k.Name,
            Value = k.Value
        }).ToList();

        return response;
    }

}
