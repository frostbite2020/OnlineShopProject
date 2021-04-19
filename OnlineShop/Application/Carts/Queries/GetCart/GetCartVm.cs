using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Carts.Queries.GetCart
{
    public class GetCartVm
    {
        public IList<GetCartDto> Carts { get; set; }
        public string TotalPriceCart { get; set; }
        public int CartCount { get; set; }
    }
}
