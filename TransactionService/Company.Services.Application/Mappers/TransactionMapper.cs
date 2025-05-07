using Company.Services.Domain.Models;
using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Riok.Mapperly.Abstractions;

namespace Company.Services.Business.Mappers;

[Mapper]
public partial class TransactionMapper
{
    public partial Transaction TransactionRequestViewModelToTransaction(TransactionRequestViewModel source);
    public partial TransactionCreatedContract TransactionToTransactionCreatedContract(Transaction source);
    public partial TransactionViewModel TransactionToTransactionViewModel(Transaction source);
}