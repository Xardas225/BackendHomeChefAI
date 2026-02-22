using WebAPI.Data;
using WebAPI.Models.Order;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task CreateOrderAsync(OrderEntity order)
    {
        await _dbContext.Orders.AddAsync(order);

        await _dbContext.SaveChangesAsync();
    }

}
