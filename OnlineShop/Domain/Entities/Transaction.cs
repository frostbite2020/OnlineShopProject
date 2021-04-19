using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public TransactionIndex TransactionIndex { get; set; }
        public int TransactionIndexId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public Status Status { get; set; }
        
    }
}