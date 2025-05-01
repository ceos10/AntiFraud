using Company.Services.Data.Contexts;
using Company.Services.Data.Interface;
using Company.Services.Data.Models;

namespace Company.Services.Data;

public class TransactionRepository
    (TransactionsDbContext db)
    : ITransactionRepository
{
    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        await db.Transactions.AddAsync(transaction);
        await db.SaveChangesAsync();
        return await db.Transactions.FindAsync(transaction.TransactionExternalId)
               ?? throw new InvalidOperationException("Transaction could not be found after creation.");
    }

    public async Task<Transaction?> GetAsync(Guid id)
    {
        return await db.Transactions.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Transaction transaction)
    {
        db.Transactions.Update(transaction);
        var changes = await db.SaveChangesAsync();
        return changes > 0;
    }
}
