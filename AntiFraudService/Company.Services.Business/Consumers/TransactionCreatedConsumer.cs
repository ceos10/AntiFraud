using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Mappers;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionCreatedConsumer(
    AntiFraudMapper antiFraudMapper,
    IAntiFraudService _antiFraudService)
    :IConsumer<TransactionCreatedContract>
{
    public async Task Consume(ConsumeContext<TransactionCreatedContract> context)
    {
        try
        {
            var transaction = context.Message;
            var transactionAntiFraud = antiFraudMapper.Map(transaction);
            await _antiFraudService.AnalyzeTransactionAsync(transactionAntiFraud);
        }
        catch (Exception)
        {
            throw;
        }
    }
}