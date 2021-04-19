using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Carts.Queries.GetCart
{
    public class GetCartDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public string ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}
