using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionCreatedConsumer(
    IAntiFraudService _antiFraudService)
    :IConsumer<TransactionCreatedContract>
{
    public async Task Consume(ConsumeContext<TransactionCreatedContract> context)
    {
        try
        {
            var transaction = context.Message;
            await _antiFraudService.AnalyzeTransactionAsync(transaction);
        }
        catch (Exception)
        {
            throw;
        }
    }
}