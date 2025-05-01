using Company.Services.Bus.Contracts;
using Company.Services.ViewModels.Transactions;
using Riok.Mapperly.Abstractions;

namespace Company.Services.Business.Mappers;

[Mapper]
public partial class AntiFraudMapper
{
    public partial TransactionAntiFraudViewModel Map(TransactionCreatedContract source);
}
