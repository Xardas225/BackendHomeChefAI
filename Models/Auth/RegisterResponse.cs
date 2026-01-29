using WebAPI.Models.User.Enums;

namespace WebAPI.Models.Auth;

public class RegisterResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }

}
