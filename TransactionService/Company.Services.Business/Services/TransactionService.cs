using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Models;
using Company.Services.Data.Interface;
using MassTransit;

namespace Company.Services.Business.Services;

public class TransactionService(
    IBusControl _busControl,
    ITopicProducer<TransactionCreatedContract> _producer,
    ITransactionRepository _transactionRepository) : ITransactionService
{
    public async Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request)
    {
        var transaction =  await _transactionRepository.CreateAsync(new Data.Models.Transaction());
        await _producer.Produce(new TransactionCreatedContract());
        return new TransactionViewModel();
    }

    public async Task<TransactionViewModel> GetTransactionTransactionAsync(Guid id)
    {
        var transaction =  await _transactionRepository.GetAsync(id);
        return new TransactionViewModel();//Convert
    }

    public async Task UpdateTransactionStatusAsync(Guid transactionId, TransactionStatus status)
    {
        var transaction = await _transactionRepository.GetAsync(transactionId);
        if (transaction == null) return;

        //transaction.Status = status;
        await _transactionRepository.UpdateAsync(transaction);
    }
}
