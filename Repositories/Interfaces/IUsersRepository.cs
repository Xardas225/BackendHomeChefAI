using WebAPI.Models.User;

namespace WebAPI.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<List<UserProfile>> GetAllUsersAsync();
    Task<UserProfile> GetUserById(int id);
    Task UpdateUser(UserProfile user);
}
