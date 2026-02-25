namespace WebAPI.Services.Interfaces;

public interface IEmbeddingService
{
    Task<float[]> GetEmbeddingAsync(string text, string type = "passage", CancellationToken cancellationToken = default);
}