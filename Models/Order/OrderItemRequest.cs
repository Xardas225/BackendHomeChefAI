namespace WebAPI.Models.Order;

public class OrderItemRequest
{
    public int DishId { get; set; }

    public int Amount { get; set; }

    public int Price { get; set; }

}
