using System.Net.Http.Headers;
using System.Text.Json;
using WebAPI.Models.Vision;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class VisionServiceClient : IVisionServiceClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public VisionServiceClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _baseUrl = config["VisionService:Url"] ?? "http://localhost:8000";
    }


    public async Task<List<DetectedObject>> DetectFoodAsync(Stream imageStream, string fileName)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            using var fileContent = new StreamContent(imageStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(fileContent, "file", fileName);

            var response = await _httpClient.PostAsync($"{_baseUrl}/detect", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DetectionResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
            return result?.Objects ?? new List<DetectedObject>();
        }
        catch (Exception ex)
        {
            return new List<DetectedObject>();
        }
    }

}
