using Company.Services.Data.Models;

namespace Company.Services.Data.Interface;

public interface ITransactionRepository
{
    Task<bool> CreateAsync(Transaction product);
    Task<Transaction> GetAsync(Guid id);
    Task<bool> UpdateAsync(Transaction product);
}
