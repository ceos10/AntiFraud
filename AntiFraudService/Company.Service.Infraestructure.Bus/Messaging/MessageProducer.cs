using Company.Services.Application.Interfaces;
using MassTransit;

namespace Company.Service.Infraestructure.Bus.Messaging;

public class MessageProducer<T>(ITopicProducer<T> _producer) : IMessageProducer<T> where T : class
{
    public async Task ProduceAsync(T message)
    {
        await _producer.Produce(message);
    }
}
