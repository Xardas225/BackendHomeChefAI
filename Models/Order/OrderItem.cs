using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Dish;

namespace WebAPI.Models.Order;

[Table("order_items")]
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public OrderEntity Order { get; set; }

    [Required]
    public int DishId { get; set; }

    [Required]
    public DishEntity Dish { get; set; }

    [Required]
    public int Amount { get; set; }
    
    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public decimal TotalPrice => Amount * UnitPrice;

}
