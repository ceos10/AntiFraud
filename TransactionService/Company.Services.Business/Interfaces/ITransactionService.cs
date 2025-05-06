using Company.Services.Domain.Models;
using Company.Services.ViewModels.Transactions;

namespace Company.Services.Business.Interfaces;

public interface ITransactionService
{
    Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request);
    Task<TransactionViewModel?> GetTransactionTransactionAsync(Guid id);
    Task UpdateTransactionStatusAsync(Guid transactionId, TransactionStatus status);
}
