using Company.Services.Application.Interfaces;
using Company.Services.Application.Mappers;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Moq;

namespace Company.Services.Transaction.Application.Tests.Base;

[TestFixture]
public abstract partial class TransactionUnitTest
{
    protected ITransactionService TransactionService { get; set; }
    protected Mock<ITransactionRepository> TransactionRepositoryMock { get; set; }
    protected TransactionMapper Mapper { get; set; }
    protected Mock<IMessageProducer<TransactionCreatedContract>> MessageProducerMock { get; set; }
}
