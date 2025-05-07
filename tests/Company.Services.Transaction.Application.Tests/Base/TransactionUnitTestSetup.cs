using Company.Services.Application.Interfaces;
using Company.Services.Application.Mappers;
using Company.Services.Application.Services;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Moq;

namespace Company.Services.Transaction.Application.Tests.Base;

public partial class TransactionUnitTest
{
    public virtual void Init()
    {
        // Initialize mocks
        TransactionRepositoryMock = new Mock<ITransactionRepository>();
        MessageProducerMock = new Mock<IMessageProducer<TransactionCreatedContract>>();

        // Initialize the mapper
        Mapper = new TransactionMapper();

        // Initialize the service
        TransactionService = new TransactionService(
            MessageProducerMock.Object,
            Mapper,
            TransactionRepositoryMock.Object
            );
    }

    [SetUp]
    public virtual void Setup()
    {
        Init();
    }
}
