using Company.Services.Bus.Contracts;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionUpdatedConsumer :
    IConsumer<TransactionUpdatedContract>
{
    public Task Consume(ConsumeContext<TransactionUpdatedContract> context)
    {
        return Task.CompletedTask;
    }
}