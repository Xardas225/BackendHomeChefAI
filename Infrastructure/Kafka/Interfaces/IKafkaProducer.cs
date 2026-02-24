namespace WebAPI.Infrastructure.Kafka.Interfaces;

public interface IKafkaProducer
{

    public Task ProduceAsync(string topic, string message);

    public Task ProduceAsync<T>(string topic, T message) where T : class;

}
