namespace Company.Services.Bus.Contracts
{
    public record TransactionCreatedContract
    {
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public int TransferTypeId { get; set; }
        public decimal Value { get; set; }
    }

    public enum TransactionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
