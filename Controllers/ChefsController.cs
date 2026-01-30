using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ChefsController : ControllerBase
{
    private readonly IChefsService _chefsService; 
    private readonly ILogger<ChefsController> _logger;


    public ChefsController (ILogger<ChefsController> logger, IChefsService chefsService)
    {
        _logger = logger;
        _chefsService = chefsService;
    }
        
    [HttpGet]
    public async Task<IActionResult> GetAllChefs()
    {
        try
        {
            _logger.LogInformation("GET-запрос списка всех шеф-поваров");
            var chefs = await _chefsService.GetAllChefsAsync();
            return Ok(chefs);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}
