using MediatR;
using WarehouseAssistant.WebApi.ViewModels;

namespace WarehouseAssistant.WebApi.Logic.Queries.Transactions
{
    public class GetTransactionsQuery : IRequest<IEnumerable<GetTransactionsViewModel>>
    {

    }
}
