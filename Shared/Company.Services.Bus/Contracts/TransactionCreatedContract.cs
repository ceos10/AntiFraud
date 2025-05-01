namespace Company.Services.Bus.Contracts
{
    public record TransactionCreatedContract
    {
        public Guid TransactionExternalId { get; set; }
        public decimal Value { get; set; }
    }
}
