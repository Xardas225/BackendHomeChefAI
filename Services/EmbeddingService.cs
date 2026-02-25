using System.Text;
using System.Text.Json;
using WebAPI.Models.Embedding;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class EmbeddingService : IEmbeddingService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<EmbeddingService> _logger;

    public EmbeddingService(HttpClient httpClient, ILogger<EmbeddingService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<float[]> GetEmbeddingAsync(string text, string type = "passage", CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new { text, type };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/embed", content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<EmbeddingResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result?.Embedding ?? throw new InvalidOperationException("Embedding is null");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get embedding for text: {Text}", text);
            throw;
        }
    }

}