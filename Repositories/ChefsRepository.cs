using WebAPI.Data;
using WebAPI.Models.Chef;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories;

public class ChefsRepository : IChefsRepository
{

    private readonly ApplicationDbContext _dbContext;

    public ChefsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }

    public async Task<List<ChefProfile>> GetAllChefsAsync()
    {
        return await _dbContext.Chefs.ToListAsync();
    }
}
