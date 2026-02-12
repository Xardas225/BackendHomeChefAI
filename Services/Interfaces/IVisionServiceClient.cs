using System.Net.Security;
using WebAPI.Models.Vision;

namespace WebAPI.Services.Interfaces;

public interface IVisionServiceClient
{
    public Task<List<DetectedObject>> DetectFoodAsync(Stream imageStream, string fileName);
}
