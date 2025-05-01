using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using MassTransit;

namespace Company.Services.Business.Consumers;

public class TransactionUpdatedConsumer(
    ITransactionService _transactionService)
    : IConsumer<TransactionUpdatedContract>
{
    public async Task Consume(ConsumeContext<TransactionUpdatedContract> context)
    {
        try
        {
            var transaction = context.Message;
            await _transactionService.UpdateTransactionStatusAsync(transaction.TransactionExternalId, (Data.Models.TransactionStatus)transaction.Status);
        }
        catch (Exception)
        {
            throw;
        }
    }
}