using WebAPI.Models.Order;

namespace WebAPI.Services.Interfaces;

public interface IOrderService
{
    public Task CreateOrderAsync(OrderRequest request);

    public Task<List<OrderResponseShort>> GetAllOrdersByUserIdAsync();

}
