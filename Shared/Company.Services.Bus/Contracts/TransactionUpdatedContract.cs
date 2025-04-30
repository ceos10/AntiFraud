namespace Company.Services.Bus.Contracts;

public record TransactionUpdatedContract
{
    public Guid TransactionId { get; set; }
    public TransactionStatus Status { get; set; }
}