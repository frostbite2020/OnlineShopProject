using System.Collections.Generic;

namespace Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionIndexDto
    {
        public GetTransactionIndexDto()
        {
            Lists = new List<GetTransactionDto>();
        }

        public int Id { get; set; }
        public string TotalTransactionPrice { get; set; }
        public IList<GetTransactionDto> Lists { get; set; }
    }
}
