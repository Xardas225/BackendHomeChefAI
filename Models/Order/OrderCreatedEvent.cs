namespace WebAPI.Models.Order;

public class OrderCreatedEvent
{

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Amount { get; set; }

    public int TotalSum { get; set; }
}
