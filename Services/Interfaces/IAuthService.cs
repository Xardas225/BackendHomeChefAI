using WebAPI.Models;
using WebAPI.Models.Auth;

namespace WebAPI.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<bool> CheckEmailExistsAsync(string email);
}
