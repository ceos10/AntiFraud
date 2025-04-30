namespace Company.Services.Bus.Interfaces;

public interface IKafkaProducer<T>
{
    Task ProduceAsync(string topic, T message, CancellationToken cancellationToken = default);
}