using Domain.Enums;

namespace Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionDto
    {
        public int Id { get; set; }
        public int TransactionIndexId { get; set; }
        public string StoreName { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public string TotalProductPrice { get; set; }
        public Status Status { get; set; }
    }
}
