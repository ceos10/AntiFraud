using System.Transactions;

namespace Company.Services.Bus.Contracts;

public class TransactionUpdatedContract
{
    public Guid TransactionId { get; set; }
    public TransactionStatus Status { get; set; }
}