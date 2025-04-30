using Company.Services.Business.Models;

namespace Company.Services.Business.Interfaces;

public interface ITransactionService
{
    Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request);
    Task<TransactionViewModel> GetTransactionTransactionAsync(Guid id);
}
