using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class KitchensController : ControllerBase
{

    private readonly IKitchensService _kitchensService;


    public KitchensController(IKitchensService kitchensService)
    {
        _kitchensService = kitchensService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllKitchens()
    {
        try
        {
            var kitchens = await _kitchensService.GetAllKitchensAsync();

            return Ok(kitchens);
        } 
        catch (Exception ex) 
        {
            return BadRequest(new { message = ex.Message });
        }

    }


}
