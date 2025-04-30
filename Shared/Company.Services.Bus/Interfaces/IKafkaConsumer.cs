namespace Company.Services.Bus.Interfaces;

public interface IKafkaConsumer
{
    Task ConsumeAsync(CancellationToken cancellationToken = default);
}
