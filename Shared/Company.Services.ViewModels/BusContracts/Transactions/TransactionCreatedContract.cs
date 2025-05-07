namespace Company.Services.Shared.Contracts.BusContracts.Transactions;

public record TransactionCreatedContract
{
    public Guid TransactionExternalId { get; set; }
    public decimal Value { get; set; }
}
