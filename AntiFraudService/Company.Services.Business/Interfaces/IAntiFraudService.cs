using Company.Services.ViewModels.Transactions;

namespace Company.Services.Business.Interfaces;

public interface IAntiFraudService
{
    Task AnalyzeTransactionAsync(TransactionAntiFraudViewModel request);
}
