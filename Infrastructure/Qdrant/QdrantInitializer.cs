using Microsoft.EntityFrameworkCore;
using Qdrant.Client;
using Qdrant.Client.Grpc;
using WebAPI.Data;
using WebAPI.Services.Interfaces;
namespace WebAPI.Infrastructure.Qdrant;

public class QdrantInitializer : IHostedService
{

    private const string СollectionName = "search_index";
    private const int VectorSize = 384;

    private readonly QdrantClient _qdrantClient;
    private readonly ILogger<QdrantInitializer> _logger;
    private readonly IEmbeddingService _embeddingService;
    private readonly IServiceProvider _serviceProvider;

    public QdrantInitializer(QdrantClient qdrantClient, 
        ILogger<QdrantInitializer> logger, 
        IEmbeddingService embeddingService,
        IServiceProvider serviceProvider)
    {
        _qdrantClient = qdrantClient;
        _logger = logger;
        _embeddingService = embeddingService;
        _serviceProvider = serviceProvider; 
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var collections = await _qdrantClient.ListCollectionsAsync(cancellationToken);
            if (!collections.Contains(СollectionName))
            {
                _logger.LogInformation("Коллекция '{СollectionName}' не найдена. Создаём...", СollectionName);

                await _qdrantClient.CreateCollectionAsync(
                    collectionName: СollectionName,
                    vectorsConfig: new VectorParams
                    {
                        Size = VectorSize,
                        Distance = Distance.Cosine
                    },
                    cancellationToken: cancellationToken
                );

                _logger.LogInformation("Коллекция '{СollectionName}' успешно создана.", СollectionName);
            }
            else
            {
                _logger.LogInformation("Коллекция '{СollectionName}' уже существует.", СollectionName);
            }


            var collectionInfo = await _qdrantClient.GetCollectionInfoAsync(СollectionName, cancellationToken);
            if (collectionInfo.PointsCount == 0)
            {
                _logger.LogInformation("Коллекция пуста. Начинаем индексацию всех постов...");
                await IndexAllExistingDishesAsync(dbContext, cancellationToken);
                _logger.LogInformation("Индексация завершена.");
            }
            else
            {
                _logger.LogInformation("Коллекция уже содержит {PointsCount} точек. Пропускаем начальную индексацию.", collectionInfo.PointsCount);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при инициализации коллекции Qdrant");
        }
    }

    private async Task IndexAllExistingDishesAsync(ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        const int batchSize = 100;
        int skip = 0;
        bool hasMore = true;
            
        while (hasMore && !cancellationToken.IsCancellationRequested)
        {
            var dishesBatch = await dbContext.Dishes
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(batchSize)
                .ToListAsync(cancellationToken);

            if (!dishesBatch.Any())
            {
                hasMore = false;
                break;
            }

            var points = new List<PointStruct>();
            foreach (var dish in dishesBatch)
            {

                if(dish == null)
                {
                    continue;
                }

                var text = $"{dish.Name} {dish.Description} {dish.Category} {dish.Kitchen}";
                var embedding = await _embeddingService.GetEmbeddingAsync(text, "passage", cancellationToken);

                var point = new PointStruct
                {
                    Id = new PointId((ulong)dish.Id),
                    Vectors = embedding,

                };

                point.Payload["name"] = dish.Name;
                point.Payload["created_at"] = dish.CreatedDate.ToString("o");
                point.Payload["category"] = dish.Category;
                point.Payload["description"] = dish.Description;
                point.Payload["price"] = (double)dish.Price;
                point.Payload["kitchen"] = dish.Kitchen;

                points.Add(point);
            }

            await _qdrantClient.UpsertAsync(СollectionName, points, cancellationToken: cancellationToken);

            skip += batchSize;
            _logger.LogDebug("Индексировано {Count} постов. Всего: {Total}", dishesBatch.Count, skip);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
