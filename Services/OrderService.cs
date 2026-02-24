using WebAPI.Infrastructure.Kafka;
using WebAPI.Infrastructure.Kafka.Interfaces;
using WebAPI.Models.Order;
using WebAPI.Models.Order.Enums;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services;

public class OrderService : IOrderService
{
    private readonly IUsersService _usersService;
    private readonly IUsersRepository _usersRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IDishesRepository _dishesRepository;
    private readonly ICartService _cartService;
    private readonly IKafkaProducer _kafkaProducer;


    public OrderService(
        IUsersService usersService, 
        IUsersRepository usersRepository, 
        IOrderRepository orderRepository,
        IDishesRepository dishesRepository,
        ICartService cartService,
        IKafkaProducer kafkaProducer)
    {
        _usersService = usersService;   
        _usersRepository = usersRepository;
        _orderRepository = orderRepository;
        _dishesRepository = dishesRepository;
        _cartService = cartService;
        _kafkaProducer = kafkaProducer;
    }

    public async Task CreateOrderAsync(OrderRequest request)
    {
        var userId = _usersService.GetRequiredUserId();
        var user = await _usersRepository.GetUserById(userId);

        if (user == null)
        {
            throw new ApplicationException($"Пользователя с ID={userId} не существует");
        }

        var createdDate = DateTime.UtcNow;
            
        var phone = request.Phone;

        var order = new OrderEntity
        {   
            User = user,
            UserId = userId,
            CreatedAt = createdDate,
            ContactPhone = phone,
            DeliveryAddress = request.DeliveryAddress,
            Email = request.Email,
            Comment = request.Comment,
            Status = OrderStatus.InWork,
            PaymentStatus = PaymentStatus.Pending,
            PaymentMethod = request.PaymentMethod,
            Items = new List<OrderItem>(),
            Amount = 0,
            TotalSum = 0
        };


        foreach (var item in request.Items)
        {
            var dish = await _dishesRepository.GetDishByIdAsync(item.DishId);

            if(dish == null)
            {
                throw new ApplicationException($"Блюда с ID={item.DishId} не существует");
            }

            var orderItem = new OrderItem
            {

                Dish = dish,
                DishId = item.DishId,
                Amount = item.Amount,
                UnitPrice  = item.Price,

            };

            order.Amount += item.Amount;

            order.TotalSum += item.Amount * item.Price;

            order.Items.Add(orderItem);
        }


        await _orderRepository.CreateOrderAsync(order);


        var createdOrderEvent = new OrderCreatedEvent
        {
            OrderId = order.Id,
            UserId = userId,
            UserName = user.Name,
            CreatedAt = order.CreatedAt,
            Amount = order.Amount,
            TotalSum = order.TotalSum,
        };

        await _kafkaProducer.ProduceAsync("order-created", createdOrderEvent);

        await _cartService.DeleteAllItemsByUserIdAsync(userId);

    }

    public async Task<List<OrderResponseShort>> GetAllOrdersByUserIdAsync()
    {
        var userId = _usersService.GetRequiredUserId();

        if(userId == null)
        {
            throw new ApplicationException($"Пользователя с ID={userId} не существует");
        }

        var orders = await _orderRepository.GetAllOrdersByUserIdAsync(userId);

        var ordersResponse = orders.Select(order =>
        new OrderResponseShort
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            TotalSum = order.TotalSum,
            Amount  = order.Amount
        }).ToList();

        return ordersResponse;
    }

    public async Task<OrderResponse> GetOrderByOrderIdAsync(int orderId)
    {
        var userId = _usersService.GetRequiredUserId();

        if (userId == null)
        {
            throw new ApplicationException($"Пользователя с ID={userId} не существует");
        }

        var order = await _orderRepository.GetOrderByOrderIdAsync(orderId, userId);

        var orderResponse = new OrderResponse
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Items = new List<OrderItemResponse>(),
            Status = order.Status,
            TotalSum = order.TotalSum,
            PaymentStatus = order.PaymentStatus,
            Amount = order.Amount,
            PaymentMethod = order.PaymentMethod,
            DeliveryAddress = order.DeliveryAddress,
            ContactPhone = order.ContactPhone,
            Email = order.Email,
            Comment = order.Comment,
        };      

        foreach (var item in order.Items)
        {
            var orderItem = new OrderItemResponse
            {
                Id = item.Id,
                DishId = item.DishId,
                DishName = item.Dish.Name,
                DishDescription = item.Dish.Description,
                DishAuthorId = item.Dish.AuthorId,
                Amount = item.Amount,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            };

            orderResponse.Items.Add(orderItem);
        }

        return orderResponse;
    }

}
