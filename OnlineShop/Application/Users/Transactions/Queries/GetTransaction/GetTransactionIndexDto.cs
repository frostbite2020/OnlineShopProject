using Domain.Enums;
using System.Collections.Generic;

namespace Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionIndexDto
    {
        public int Id { get; set; }
        public string TotalTransactionPrice { get; set; }
        public int Status { get; set; }
        public GetTransactionStoreDto Store { get; set; }
        public GetTransactionShippingDto ShippingMethod { get; set; }
        public GetTransactionPaymentDto PaymentMethod { get; set; }
        public GetTransactionAdditionalDataDto AdditionalData { get; set; }
        public IList<GetTransactionDto> Lists { get; set; }
    }
}
