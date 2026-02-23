using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Order;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{

    private readonly IOrderService _orderService;
    private readonly IUsersService _usersService;

    public OrdersController(IOrderService orderService, IUsersService usersService)
    {
        _orderService = orderService; 
        _usersService = usersService;
    }
            
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderRequest request)
    {
        try
        { 
            await _orderService.CreateOrderAsync(request);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrdersByUserId()
    {
        try
        {
            var orders = await _orderService.GetAllOrdersByUserIdAsync();

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByOrderId(int id)
    {
        try
        {
            var order = await _orderService.GetOrderByOrderIdAsync(id);

            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

}
