using Company.Services.Bus.Contracts;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionUpdatedConsumer
    :IConsumer<TransactionUpdatedContract>
{
    public async Task Consume(ConsumeContext<TransactionUpdatedContract> context)
    {
        try
        {
            var test = context.Message;
        }
        catch (Exception)
        {
            throw;
        }
    }
}