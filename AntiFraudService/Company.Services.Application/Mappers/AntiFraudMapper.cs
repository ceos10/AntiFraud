using Company.Services.Shared.Contracts.BusContracts.Transactions;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Riok.Mapperly.Abstractions;

namespace Company.Services.Business.Mappers;

[Mapper]
public partial class AntiFraudMapper
{
    public partial TransactionAntiFraudViewModel Map(TransactionCreatedContract source);
}
