using Company.Services.Application.Interfaces;
using Company.Services.Application.Services;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Moq;

namespace Company.Services.AntiFraud.Application.Tests.Base;

public partial class AntiFraudUnitTest
{
    public virtual void Init()
    {
        // Initialize mocks
        MessageProducerMock = new Mock<IMessageProducer<TransactionUpdatedContract>>();

        // Initialize the service
        AntiFraudService = new AntiFraudService(
            MessageProducerMock.Object
            );
    }

    [SetUp]
    public virtual void Setup()
    {
        Init();
    }
}
