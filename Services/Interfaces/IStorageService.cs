using WebAPI.Models.File;

namespace WebAPI.Services.Interfaces;

public interface IStorageService
{
    public Task<string> UploadFileAsync(IFormFile file);

    public Task<string> SetUserAvatar(FileRecordRequest request);
}
