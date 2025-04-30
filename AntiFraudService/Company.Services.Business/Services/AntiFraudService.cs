using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using MassTransit;

namespace Company.Services.Business.Services;

public class AntiFraudService(
    ITopicProducer<TransactionUpdatedContract> _producer)
    : IAntiFraudService
{
    public async Task AnalyzeTransactionAsync(TransactionCreatedContract message)
    {
        //var status = (message.Value > 2000) ? TransactionStatus.Rejected : TransactionStatus.Approved;

        await _producer.Produce(new TransactionUpdatedContract());
    }
}
