using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{

    private readonly ICategoriesService _categoriesService;
    
    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService; 
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        try
        {

            var categories = await _categoriesService.GetAllCategoriesAsync();

            return Ok(categories);
        } 
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


}
