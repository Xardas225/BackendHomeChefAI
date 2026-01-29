using System.ComponentModel.DataAnnotations;
using WebAPI.Models.User.Enums;
namespace WebAPI.Models.Auth;

public class LoginRequest
{
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    [StringLength(255, ErrorMessage = "Email не должен превышать 255 символов")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен")]
    [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Пароль обязателен")]
    [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
    public UserRole Role { get; set; }
}


