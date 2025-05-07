using Company.Services.Domain.Models;
using Company.Services.Shared.Contracts.ViewModels.Transactions;

namespace Company.Services.Application.Interfaces;

public interface ITransactionService
{
    Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request);
    Task<TransactionViewModel?> GetTransactionAsync(Guid id);
    Task UpdateTransactionStatusAsync(Guid transactionId, TransactionStatus status);
}
