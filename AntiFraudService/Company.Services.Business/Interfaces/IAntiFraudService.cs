using Company.Services.Bus.Contracts;

namespace Company.Services.Business.Interfaces;

public interface IAntiFraudService
{
    Task AnalyzeTransactionAsync(TransactionCreatedContract message);
}
