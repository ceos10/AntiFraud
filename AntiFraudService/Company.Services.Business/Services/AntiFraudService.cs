using Company.Services.Bus.Contracts;
using Company.Services.Bus.Interfaces;
using Company.Services.Business.Interfaces;

namespace Company.Services.Business.Services;

public class AntiFraudService: IAntiFraudService
{
    public AntiFraudService()
    {
    }

    public async Task AnalyzeTransactionAsync(TransactionCreatedContract message)
    {
        //var status = (message.Value > 2000) ? TransactionStatus.Rejected : TransactionStatus.Approved;

        // Simulate more complex logic, like daily accumulated value, etc.

        // Publish decision to Kafka: transaction-status-updated
        //await _kafkaProducer.ProduceAsync("transaction-updated", new TransactionUpdatedContract());
    }
}
