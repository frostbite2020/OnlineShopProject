namespace Domain.Entities
{
    public class TransactionIndex
    {
        public int Id { get; set; }
        public UserProperty UserProperty { get; set; }
        public int UserPropertyId { get; set; }
        public int TotalTransactionPrice { get; set; }
    }
}
