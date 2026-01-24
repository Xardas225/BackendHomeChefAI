using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Auth;

public class RegisterRequest
{
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    [StringLength(255, ErrorMessage = "Email не должен превышать 255 символов")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен")]
    [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$",
        ErrorMessage = "Пароль должен содержать минимум одну заглавную букву, одну строчную и одну цифру")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Подтверждение пароля обязательно")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(100, ErrorMessage = "Фамилия не должна превышать 100 символов")]
    public string LastName { get; set; }
}
