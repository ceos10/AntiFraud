using Company.Services.Application.Interfaces;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions.Enums;

namespace Company.Services.Application.Services;

public class AntiFraudService(
    IMessageProducer<TransactionUpdatedContract> _messageProducer)
    : IAntiFraudService
{
    public async Task AnalyzeTransactionAsync(TransactionAntiFraudViewModel request)
    {
        var transactionUpdated = new TransactionUpdatedContract {
            TransactionExternalId = request.TransactionExternalId,
            Status = request.Value > 2000 ? (int)TransactionStatusViewModel.Rejected : (int)TransactionStatusViewModel.Approved
        };

        await _messageProducer.ProduceAsync(transactionUpdated);
    }
}
