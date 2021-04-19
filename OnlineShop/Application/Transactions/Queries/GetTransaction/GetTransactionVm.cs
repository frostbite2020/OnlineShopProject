using Domain.Enums;
using System.Collections.Generic;

namespace Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionVm
    {
        public IList<GetTransactionIndexDto> Transactions { get; set; }
    }
}
