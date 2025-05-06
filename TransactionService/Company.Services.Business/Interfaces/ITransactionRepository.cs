using Company.Services.Domain.Models;

namespace Company.Services.Application.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction?> GetAsync(Guid id);
    Task<bool> UpdateAsync(Transaction transaction);
}

