using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Company.Services.Transaction.Application.Tests.Base;
using Moq;

namespace Company.Services.Transaction.Application.Tests;

public class CreateTransactionTests: TransactionUnitTest
{
    [Test]
    public async Task CreateTransactionAsync_ShouldCreateTransactionAndProduceMessage()
    {
        // Arrange
        var request = new TransactionRequestViewModel
        {
            SourceAccountId = Guid.NewGuid(),
            TargetAccountId = Guid.NewGuid(),
            TransferTypeId = 1,
            Value = 1000
        };

        var transaction = new Domain.Models.Transaction
        {
            TransactionExternalId = Guid.NewGuid(),
            Value = request.Value
        };

        var transactionViewModel = new TransactionViewModel
        {
            TransactionExternalId = transaction.TransactionExternalId
        };

        TransactionRepositoryMock
            .Setup(repo => repo.CreateAsync(It.IsAny<Domain.Models.Transaction>()))
            .ReturnsAsync(transaction);

        MessageProducerMock
            .Setup(producer => producer.ProduceAsync(It.IsAny<TransactionCreatedContract>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await TransactionService.CreateTransactionAsync(request);

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(transactionViewModel.TransactionExternalId, Is.EqualTo(result.TransactionExternalId));
        });

        TransactionRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Models.Transaction>()), Times.Once);
        MessageProducerMock.Verify(producer => producer.ProduceAsync(It.IsAny<TransactionCreatedContract>()), Times.Once);
    }
}
