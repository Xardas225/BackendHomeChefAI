using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Cart;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ILogger<CartRepository> _logger;
    private readonly ApplicationDbContext _dbContext; 

    public CartRepository(ApplicationDbContext dbContext, ILogger<CartRepository> logger)
    {
        _dbContext = dbContext; 
        _logger = logger;
    }

    public async Task AddItemToCartAsync(CartEntity item)
    {
        _dbContext.CartItems.AddAsync(item);

        await _dbContext.SaveChangesAsync();
    }


    public Task GetItemsFromCartAsync()
    {
        return Task.CompletedTask;
    }

    public async Task<int> GetCountItemsByUserIdAsync(int userId)
    {

        var items = await _dbContext.CartItems.ToListAsync();

         var count = await _dbContext.CartItems.Where(c => c.UserId == userId).SumAsync(c => c.Amount);
        _logger.LogInformation("CART ITEMS {@userId}", userId); 


        return count;
    }

}
