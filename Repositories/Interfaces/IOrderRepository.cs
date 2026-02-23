using WebAPI.Models.Order;

namespace WebAPI.Repositories.Interfaces;

public interface IOrderRepository
{
    public Task CreateOrderAsync(OrderEntity order);

    public Task<List<OrderEntity>> GetAllOrdersByUserIdAsync(int userId);
}
