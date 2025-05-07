using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Company.Services.Transaction.Application.Tests.Base;
using Moq;

namespace Company.Services.Transaction.Application.Tests;

public class GetTransactionTests : TransactionUnitTest
{
    [Test]
    public async Task GetTransactionAsync_ShouldReturnTransactionViewModel_WhenTransactionExists()
    {
        // Arrange
        var transactionId = Guid.NewGuid();
        var transaction = new Domain.Models.Transaction
        {
            TransactionExternalId = transactionId,
            Value = 1000
        };

        var transactionViewModel = new TransactionViewModel
        {
            TransactionExternalId = transaction.TransactionExternalId
        };

        TransactionRepositoryMock
            .Setup(repo => repo.GetAsync(transactionId))
            .ReturnsAsync(transaction);

        // Act
        var result = await TransactionService.GetTransactionAsync(transactionId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.TransactionExternalId, Is.EqualTo(transactionViewModel.TransactionExternalId));

        TransactionRepositoryMock.Verify(repo => repo.GetAsync(transactionId), Times.Once);
    }

    [Test]
    public async Task GetTransactionAsync_ShouldReturnNull_WhenTransactionDoesNotExist()
    {
        // Arrange
        var transactionId = Guid.NewGuid();

        TransactionRepositoryMock
            .Setup(repo => repo.GetAsync(transactionId))
            .ReturnsAsync((Domain.Models.Transaction)null);

        // Act
        var result = await TransactionService.GetTransactionAsync(transactionId);

        // Assert
        Assert.That(result, Is.Null);
        TransactionRepositoryMock.Verify(repo => repo.GetAsync(transactionId), Times.Once);
    }
}
