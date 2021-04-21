using Application.Carts.Commands.CreateCart;
using Application.Carts.Commands.DeleteCart;
using Application.Carts.Queries.GetCart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("cart")]
    public class CartController : ApiControllerBase
    {
        [HttpGet("{userPropertyId}")]
        public async Task<GetCartVm> GetAll(int userPropertyId)
        {
            return await Mediator.Send(new GetCartQuery { UserId = userPropertyId });
        }

        [HttpPost]
        public async Task<string> Add(CreateCartCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await Mediator.Send(new DeleteCartCommand { Id = id });
        }
    }
}
