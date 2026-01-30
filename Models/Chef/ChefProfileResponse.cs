using WebAPI.Models.Chef.Enums;

namespace WebAPI.Models.Chef;

public class ChefProfileResponse
{
    public int Id { get; set; }
    public string? KitchenName { get; set; }
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public decimal Rating { get; set; } = 0;

    public int TotalOrders { get; set; } = 0;

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public ChefExperience ChefExperience { get; set; }
}
