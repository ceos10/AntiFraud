using Company.Services.Bus.Contracts;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionCreatedConsumer :
    IConsumer<TransactionCreatedContract>
{
    public Task Consume(ConsumeContext<TransactionCreatedContract> context)
    {
        return Task.CompletedTask;
    }
}