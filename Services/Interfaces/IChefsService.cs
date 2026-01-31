using WebAPI.Models.Chef;

namespace WebAPI.Services.Interfaces;

public interface IChefsService
{
    Task<List<ChefProfileResponse>> GetAllChefsAsync();

    Task<ChefProfileResponse> GetChefByUserIdAsync(int id);
}
