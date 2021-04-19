using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public UserProperty UserProperty { get; set; }
        public int UserPropertyId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity{ get; set; }
        public int TotalPrice { get; set; }
    }
}
