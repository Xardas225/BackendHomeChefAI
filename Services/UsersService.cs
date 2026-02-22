using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAPI.Models.User;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;
namespace WebAPI.Services;
public class UsersService : IUsersService
{   

    private readonly IUsersRepository _usersRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersService(IUsersRepository usersRepository, IHttpContextAccessor httpContextAccessor)
    {
        _usersRepository = usersRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<UserResponse>> GetAllUsersAsync()
    {
        var users = await _usersRepository.GetAllUsersAsync();
        
        return users.Select(user => new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Phone = user.Phone
        }).ToList();
    }

    public async Task<UserResponse> GetUserById(int id)
    {
        var user = await _usersRepository.GetUserById(id);
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Phone = user.Phone,
            AvatarUrl = user.AvatarUrl
        };

    }

    public async Task<UserResponse> UpdateUserById(int id, UpdateUserRequest request)
    {
        var user = await _usersRepository.GetUserById(id);

        user.Update(request.Email, request.Name, request.LastName, request.Phone);

        await _usersRepository.UpdateUser(user);

        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Phone = user.Phone
        };
    }

    public int? UserId
    {   
        get
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true)
                return null;

            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null && int.TryParse(claim.Value, out var id))
                return id;

            return null;
        }
    }

    public int GetRequiredUserId()
    {
        var id = UserId;
        if (!id.HasValue)
            throw new UnauthorizedAccessException("Пользователь не аутентифицирован или идентификатор не найден");
        return id.Value;
    }
}

