using Company.Services.Domain.Models;
using Company.Services.Transaction.Application.Tests.Base;
using Moq;

namespace Company.Services.Transaction.Application.Tests;

public class UpdateTransactionStatusTests : TransactionUnitTest
{
    [Test]
    public async Task UpdateTransactionStatusAsync_ShouldUpdateTransactionStatus_WhenTransactionExists()
    {
        // Arrange
        var transactionId = Guid.NewGuid();
        var transaction = new Domain.Models.Transaction
        {
            TransactionExternalId = transactionId,
            Status = TransactionStatus.Pending
        };

        TransactionRepositoryMock
            .Setup(repo => repo.GetAsync(transactionId))
            .ReturnsAsync(transaction);

        TransactionRepositoryMock
            .Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Models.Transaction>()))
            .ReturnsAsync(true);

        // Act
        await TransactionService.UpdateTransactionStatusAsync(transactionId, TransactionStatus.Approved);

        // Assert
        Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Approved));
        TransactionRepositoryMock.Verify(repo => repo.GetAsync(transactionId), Times.Once);
        TransactionRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Domain.Models.Transaction>()), Times.Once);
    }

    [Test]
    public async Task UpdateTransactionStatusAsync_ShouldDoNothing_WhenTransactionDoesNotExist()
    {
        // Arrange
        var transactionId = Guid.NewGuid();

        TransactionRepositoryMock
            .Setup(repo => repo.GetAsync(transactionId))
            .ReturnsAsync((Domain.Models.Transaction?)null);

        // Act
        await TransactionService.UpdateTransactionStatusAsync(transactionId, TransactionStatus.Approved);

        // Assert
        TransactionRepositoryMock.Verify(repo => repo.GetAsync(transactionId), Times.Once);
        TransactionRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Domain.Models.Transaction>()), Times.Never);
    }
}
