namespace WebAPI.Models.Vision;

public class DetectedObject
{
    public string Label { get; set; } = "";
    public float Confidence { get; set; }
    public List<float> Bbox { get; set; } = new();
}
