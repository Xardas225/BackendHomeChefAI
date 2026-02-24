using Confluent.Kafka;
using System.Text.Json;
using WebAPI.Infrastructure.Kafka.Interfaces;

namespace WebAPI.Infrastructure.Kafka;


public class KafkaProducer : IKafkaProducer, IDisposable
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer(ProducerConfig config)
    {
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
    }

    public async Task ProduceAsync<T>(string topic, T message) where T : class
    {
        var json = JsonSerializer.Serialize(message);   
        await ProduceAsync(topic, json);
    }

    public void Dispose()
    {
        _producer?.Dispose();
    }
}
