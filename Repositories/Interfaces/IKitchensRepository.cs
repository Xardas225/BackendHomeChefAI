using WebAPI.Models.Dish.Kitchens;

namespace WebAPI.Repositories.Interfaces;

public interface IKitchensRepository
{

    public Task<List<KitchensEntity>> GetAllKitchensAsync();

}
