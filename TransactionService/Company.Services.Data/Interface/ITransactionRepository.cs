using Company.Services.Data.Models;

namespace Company.Services.Data.Interface;

public interface ITransactionRepository
{
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction?> GetAsync(Guid id);
    Task<bool> UpdateAsync(Transaction transaction);
}
