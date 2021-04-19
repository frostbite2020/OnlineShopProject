using Application.Carts.Commands.CreateCart;
using Application.Carts.Queries.GetCart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("cart")]
    public class CartController : ApiControllerBase
    {
        [HttpGet("{userPropertyId}")]
        public async Task<GetCartVm> GetAll(int userPropertyId)
        {
            var query = new GetCartQueries();
            query.UserPropertyId = userPropertyId;
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<int> Add(CreateCartCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
