namespace Company.Services.Bus.Contracts;

public record TransactionUpdatedContract
{
    public Guid TransactionExternalId { get; set; }
    public int Status { get; set; }
}