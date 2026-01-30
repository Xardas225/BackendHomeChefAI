using WebAPI.Models.Chef;
using WebAPI.Models.Chef.Enums;
using WebAPI.Models.User;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class ChefsService : IChefsService
{

    private readonly IChefsRepository _chefsRepository;

    public ChefsService(IChefsRepository chefsRepository)
    {
        _chefsRepository = chefsRepository;
    }

    public async Task<List<ChefProfileResponse>> GetAllChefsAsync()
    {
        var chefs = await _chefsRepository.GetAllChefsAsync();

        return chefs.Select(chef => new ChefProfileResponse
        {
            Id = chef.Id,
            KitchenName = chef.KitchenName,
            Description = chef.Description,
            IsActive = chef.IsActive,
            Rating = chef.Rating,
            TotalOrders = chef.TotalOrders,
            StartTime = chef.StartTime,
            EndTime = chef.EndTime,
            ChefExperience = chef.ChefExperience
        }).ToList();
    }

}
