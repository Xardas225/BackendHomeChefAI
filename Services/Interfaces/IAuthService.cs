using WebAPI.Models;
using WebAPI.Models.Auth;

namespace WebAPI.Services.Interfaces;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<bool> CheckEmailExistsAsync(string email);
}
