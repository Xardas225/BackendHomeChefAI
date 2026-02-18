using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Dish.Kitchens;


[Table("kitchens")]
public class KitchensEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Value { get; set; }

}
