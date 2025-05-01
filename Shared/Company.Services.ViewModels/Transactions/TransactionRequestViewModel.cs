namespace Company.Services.ViewModels.Transactions;

public record TransactionRequestViewModel
{
    public Guid SourceAccountId { get; set; }
    public Guid TargetAccountId { get; set; }
    public int TransferTypeId { get; set; }
    public decimal Value { get; set; }
}