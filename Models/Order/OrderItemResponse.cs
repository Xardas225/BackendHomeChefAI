namespace WebAPI.Models.Order;

public class OrderItemResponse
{
    public int Id { get; set; }

    public int DishId { get; set; }

    public string DishName { get; set; }

    public string DishDescription { get; set; }

    public int DishAuthorId { get; set; }

    public int Amount { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }
}
