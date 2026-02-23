using WebAPI.Models.Order.Enums;

namespace WebAPI.Models.Order;

public class OrderResponse
{

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<OrderItemResponse> Items { get; set; }

    public OrderStatus Status { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public int TotalSum { get; set; }

    public int Amount { get; set; }

    public string DeliveryAddress { get; set; }

    public string ContactPhone { get; set; }

    public string Email { get; set; }

    public string Comment { get; set; }
}
