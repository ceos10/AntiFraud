using Company.Services.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Services.Data.Contexts;

public class TransactionsDbContext : DbContext
{
    public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options)
        : base(options) { }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionExternalId);
            entity.Property(e => e.Status)
                .HasConversion<int>();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
