using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using Company.Services.ViewModels.Transactions;
using Company.Services.ViewModels.Transactions.Enums;
using MassTransit;

namespace Company.Services.Business.Services;

public class AntiFraudService(
    ITopicProducer<TransactionUpdatedContract> _producer)
    : IAntiFraudService
{
    public async Task AnalyzeTransactionAsync(TransactionAntiFraudViewModel request)
    {
        var transactionUpdated = new TransactionUpdatedContract {
            TransactionExternalId = request.TransactionExternalId,
            Status = request.Value > 2000 ? (int)TransactionStatusViewModel.Rejected : (int)TransactionStatusViewModel.Approved
        };

        await _producer.Produce(transactionUpdated);
    }
}
