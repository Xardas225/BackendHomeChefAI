using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Dish.Kitchens;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories;

public class KitchensRepository : IKitchensRepository
{

    private readonly ApplicationDbContext _dbContext;

    public KitchensRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<KitchensEntity>> GetAllKitchensAsync()
    {
        return await _dbContext.Kitchens.ToListAsync();
    }

}
