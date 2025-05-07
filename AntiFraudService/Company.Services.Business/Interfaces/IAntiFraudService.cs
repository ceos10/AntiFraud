using Company.Services.Shared.Contracts.ViewModels.Transactions;

namespace Company.Services.Business.Interfaces;

public interface IAntiFraudService
{
    Task AnalyzeTransactionAsync(TransactionAntiFraudViewModel request);
}
