using Company.Services.Bus.Interfaces;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Company.Services.Bus;

public class KafkaProducer<T> : IKafkaProducer<T>
{
    private readonly IProducer<Null, string> _producer;
    private readonly ILogger<KafkaProducer<T>> _logger;

    public KafkaProducer(ILogger<KafkaProducer<T>> logger)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "kafka:29092",//"localhost:9092"
            AllowAutoCreateTopics = true
        };

        _producer = new ProducerBuilder<Null, string>(config).Build();
        _logger = logger;
    }

    public async Task ProduceAsync(string topic, T message, CancellationToken cancellationToken = default)
    {
        var jsonMessage = JsonSerializer.Serialize(message);

        try
        {
            var result = await _producer.ProduceAsync(topic, new Message<Null, string> { Value = jsonMessage }, cancellationToken);
            _logger.LogInformation("Produced message to {Topic}, offset: {Offset}", topic, result.Offset);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to produce message to {Topic}", topic);
        }
    }
}
