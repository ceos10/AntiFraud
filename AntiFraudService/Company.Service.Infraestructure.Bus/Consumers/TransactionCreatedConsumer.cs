using Company.Services.Business.Interfaces;
using Company.Services.Business.Mappers;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using MassTransit;

namespace Company.Service.Infraestructure.Bus.Consumers;

public class TransactionCreatedConsumer(
    AntiFraudMapper antiFraudMapper,
    IAntiFraudService _antiFraudService)
    : IConsumer<TransactionCreatedContract>
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
