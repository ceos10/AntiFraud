using Company.Services.Bus.Contracts;
using Company.Services.Business.Interfaces;
using Company.Services.Business.Mappers;
using Company.Services.Data.Interface;
using Company.Services.ViewModels.Transactions;
using MassTransit;

namespace Company.Services.Business.Services;

public class TransactionService(
    ITopicProducer<TransactionCreatedContract> _producer,
    TransactionMapper _mapper,
    ITransactionRepository _transactionRepository) : ITransactionService
{
    public async Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request)
    {
        var transactionDbRequest = _mapper.TransactionRequestViewModelToTransaction(request);
        var transaction =  await _transactionRepository.CreateAsync(transactionDbRequest);
        var transactionMessage = _mapper.TransactionToTransactionCreatedContract(transaction);
        await _producer.Produce(transactionMessage);
        return _mapper.TransactionToTransactionViewModel(transaction);
    }

    public async Task<TransactionViewModel> GetTransactionTransactionAsync(Guid id)
    {
        var transaction =  await _transactionRepository.GetAsync(id);
        return _mapper.TransactionToTransactionViewModel(transaction);
    }

    public async Task UpdateTransactionStatusAsync(Guid transactionId, Data.Models.TransactionStatus status)
    {
        var transaction = await _transactionRepository.GetAsync(transactionId);
        if (transaction == null)
            return;

        transaction.Status = status;
        await _transactionRepository.UpdateAsync(transaction);
    }
}
