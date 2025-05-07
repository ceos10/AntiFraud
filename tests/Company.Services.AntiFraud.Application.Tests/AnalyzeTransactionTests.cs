using Company.Services.AntiFraud.Application.Tests.Base;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions.Enums;
using Moq;

namespace Company.Services.AntiFraud.Application.Tests;

public class AnalyzeTransactionTests: AntiFraudUnitTest
{
    [Test]
    public async Task AnalyzeTransactionAsync_ShouldApproveTransaction_WhenValueIsBelowThreshold()
    {
        // Arrange
        var transaction = new TransactionAntiFraudViewModel
        {
            TransactionExternalId = Guid.NewGuid(),
            Value = 1500 // Below threshold (2000)
        };

        // Act
        await AntiFraudService.AnalyzeTransactionAsync(transaction);

        // Assert
        MessageProducerMock.Verify(producer =>
            producer.ProduceAsync(It.Is<TransactionUpdatedContract>(contract =>
                contract.TransactionExternalId == transaction.TransactionExternalId &&
                contract.Status == (int)TransactionStatusViewModel.Approved)),
            Times.Once);
    }

    [Test]
    public async Task AnalyzeTransactionAsync_ShouldRejectTransaction_WhenValueIsAboveThreshold()
    {
        // Arrange
        var transaction = new TransactionAntiFraudViewModel
        {
            TransactionExternalId = Guid.NewGuid(),
            Value = 2500 // Above threshold (2000)
        };

        // Act
        await AntiFraudService.AnalyzeTransactionAsync(transaction);

        // Assert
        MessageProducerMock.Verify(producer =>
            producer.ProduceAsync(It.Is<TransactionUpdatedContract>(contract =>
                contract.TransactionExternalId == transaction.TransactionExternalId &&
                contract.Status == (int)TransactionStatusViewModel.Rejected)),
            Times.Once);
    }

    [Test]
    public async Task AnalyzeTransactionAsync_ShouldCallMessageProducer()
    {
        // Arrange
        var transaction = new TransactionAntiFraudViewModel
        {
            TransactionExternalId = Guid.NewGuid(),
            Value = 1000 // Any value
        };

        // Act
        await AntiFraudService.AnalyzeTransactionAsync(transaction);

        // Assert
        MessageProducerMock.Verify(producer =>
            producer.ProduceAsync(It.IsAny<TransactionUpdatedContract>()),
            Times.Once);
    }
}
