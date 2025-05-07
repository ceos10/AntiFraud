using Company.Services.Application.Interfaces;
using Company.Services.Application.Mappers;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;

namespace Company.Services.Application.Services;

public class TransactionService(
    IMessageProducer<TransactionCreatedContract> _producer,
    TransactionMapper _mapper,
    ITransactionRepository _transactionRepository) : ITransactionService
{
    public async Task<TransactionViewModel> CreateTransactionAsync(TransactionRequestViewModel request)
    {
        var transactionDbRequest = _mapper.TransactionRequestViewModelToTransaction(request);
        var transaction =  await _transactionRepository.CreateAsync(transactionDbRequest);
        var transactionMessage = _mapper.TransactionToTransactionCreatedContract(transaction);
        await _producer.ProduceAsync(transactionMessage);
        return _mapper.TransactionToTransactionViewModel(transaction);
    }

    public async Task<TransactionViewModel?> GetTransactionTransactionAsync(Guid id)
    {
        var transaction =  await _transactionRepository.GetAsync(id);
        return transaction is null
            ? null
            : _mapper.TransactionToTransactionViewModel(transaction);
    }

    public async Task UpdateTransactionStatusAsync(Guid transactionId, Domain.Models.TransactionStatus status)
    {
        var transaction = await _transactionRepository.GetAsync(transactionId);
        if (transaction == null)
            return;

        transaction.Status = status;
        await _transactionRepository.UpdateAsync(transaction);
    }
}
