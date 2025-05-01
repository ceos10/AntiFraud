namespace Company.Services.Data.Models;

public record Transaction
{
    public Guid SourceAccountId { get; set; }
    public Guid TargetAccountId { get; set; }
    public int TransferTypeId { get; set; }
    public decimal Value { get; set; }
    public Guid TransactionExternalId { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
}

public enum TransactionStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}
