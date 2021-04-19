using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TransactionIndex
    {
        public int Id { get; set; }
        public UserProperty UserProperty { get; set; }
        public int UserPropertyId { get; set; }
        public int TotalTransactionPrice { get; set; }
        public IList<Transaction> Lists { get; private set; } = new List<Transaction>();

    }
}
