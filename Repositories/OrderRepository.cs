using Microsoft.EntityFrameworkCore;
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

    public async Task<List<OrderEntity>> GetAllOrdersByUserIdAsync(int userId)
    {
        return await _dbContext.Orders.Where(order => order.UserId == userId)
                                      .ToListAsync();
    }

    public async Task<OrderEntity> GetOrderByOrderIdAsync(int orderId, int userId)
    {
        return await _dbContext.Orders.Include(o => o.Items)
                                      .ThenInclude(i => i.Dish)
                                      .FirstOrDefaultAsync(order => order.Id == orderId && order.UserId == userId);
    }

}
