using Company.Services.Application.Interfaces;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using MassTransit;

namespace Company.Service.Infraestructure.Bus.Consumers;

public class TransactionUpdatedConsumer(
    ITransactionService _transactionService)
    : IConsumer<TransactionUpdatedContract>
{
    public async Task Consume(ConsumeContext<TransactionUpdatedContract> context)
    {
        try
        {
            var transaction = context.Message;
            await _transactionService.UpdateTransactionStatusAsync(transaction.TransactionExternalId, (Services.Domain.Models.TransactionStatus)transaction.Status);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
