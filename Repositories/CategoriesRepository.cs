using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Dish.Categories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories;

public class CategoriesRepository : ICategoriesRepository   
{

    private readonly ApplicationDbContext _dbContext;

    public CategoriesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }

    public async Task<List<CategoryEntity>> GetCategoryEntitiesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }
}
