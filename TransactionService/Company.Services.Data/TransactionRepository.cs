using Company.Services.Data.Interface;
using Company.Services.Data.Models;

namespace Company.Services.Data;

public class TransactionRepository : ITransactionRepository
{
    public async Task<Transaction> CreateAsync(Transaction product)
    {
        return await Task.FromResult(new Transaction());
    }

    public async Task<Transaction> GetAsync(Guid id)
    {
        return await Task.FromResult(new Transaction { });
    }

    public async Task<bool> UpdateAsync(Transaction product)
    {
        return await Task.FromResult(true);
    }
}
