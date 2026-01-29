namespace WebAPI.Models.Chef;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Chef.Enums;
using WebAPI.Models.User;

[Table("chefs")]
public class ChefProfile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string KitchenName { get; set; }
    public string Description { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public decimal Rating { get; set; } = 0;

    [Required]
    public int TotalOrders { get; set; } = 0;

    // График работы
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    // Связь с пользователем
    public UserProfile User { get; set; }

    [Required]
    // Опыт работы
    public ChefExperience ChefExperience { get; set; }  

}
