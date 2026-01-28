namespace WebAPI.Models.Auth;
public class LoginResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpiry { get; set; }
}
