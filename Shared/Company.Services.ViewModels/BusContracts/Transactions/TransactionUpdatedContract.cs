namespace Company.Services.Shared.Contracts.BusContracts.Transactions;

public record TransactionUpdatedContract
{
    public Guid TransactionExternalId { get; set; }
    public int Status { get; set; }
}
