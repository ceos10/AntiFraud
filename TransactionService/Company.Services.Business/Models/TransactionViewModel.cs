namespace Company.Services.Business.Models;

public record TransactionViewModel
{
    public Guid TransactionExternalId { get; set; }
    public DateTime CreatedAt { get; set; }
}
