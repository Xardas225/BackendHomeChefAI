using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DetectionController : ControllerBase
{
    private readonly IVisionServiceClient _visionService;

    public DetectionController(IVisionServiceClient visionService)
    {
        _visionService = visionService; 
    }

    [HttpPost]
    public async Task<IActionResult> DetectFood(IFormFile file)
    {   
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        if (!file.ContentType.StartsWith("image/"))
            return BadRequest("File is not an image");


        try
        {
            await using var stream = file.OpenReadStream();

            var detected = await _visionService.DetectFoodAsync(stream, file.FileName);

            return Ok(new
            {
                success = true,
                objects = detected,
                count = detected.Count
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = "Detection failed" });
        }

        
    }

}
