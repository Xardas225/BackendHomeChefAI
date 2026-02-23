using WebAPI.Models.Order.Enums;

namespace WebAPI.Models.Order;

public class OrderResponseShort
{

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public OrderStatus Status { get; set; }

    public int TotalSum { get; set; }

    public int Amount { get; set; }

}
