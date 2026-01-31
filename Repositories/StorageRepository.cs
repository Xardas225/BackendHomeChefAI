namespace WebAPI.Repositories;

using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.File;
using WebAPI.Repositories.Interfaces;

public class StorageRepository : IStorageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StorageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UploadFileAsync(FileRecord file)
    {
        _dbContext.Files.Add(file);

        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == file.UserId);
        if (user != null) 
        {
            user.AvatarUrl = file.Url;
        }


        await  _dbContext.SaveChangesAsync();
    }
}
