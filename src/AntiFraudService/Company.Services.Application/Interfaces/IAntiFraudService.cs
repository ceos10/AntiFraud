using Company.Services.Shared.Contracts.ViewModels.Transactions;

namespace Company.Services.Application.Interfaces;

public interface IAntiFraudService
{
    Task AnalyzeTransactionAsync(TransactionAntiFraudViewModel request);
}
