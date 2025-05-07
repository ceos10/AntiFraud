namespace Company.Services.Application.Interfaces;

public interface IMessageProducer<in T> where T : class
{
    Task ProduceAsync(T message);
}
