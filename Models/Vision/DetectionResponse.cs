namespace WebAPI.Models.Vision;

public class DetectionResponse
{
    public bool Success { get; set; }
    public List<DetectedObject> Objects { get; set; } = new();
    public string Message { get; set; } = "";
}
