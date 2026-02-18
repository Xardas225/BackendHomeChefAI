using WebAPI.Models.Dish.Kitchens;

namespace WebAPI.Services.Interfaces;

public interface IKitchensService
{
    public Task<List<KitchensDto>> GetAllKitchensAsync();
}
