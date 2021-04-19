using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Transaction Transaction { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
