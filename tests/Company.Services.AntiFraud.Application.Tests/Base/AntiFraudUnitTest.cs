using Company.Services.Application.Interfaces;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Moq;

namespace Company.Services.AntiFraud.Application.Tests.Base;

[TestFixture]
public abstract partial class AntiFraudUnitTest
{
    protected IAntiFraudService AntiFraudService { get; set; }
    protected Mock<IMessageProducer<TransactionUpdatedContract>> MessageProducerMock { get; set; }
}