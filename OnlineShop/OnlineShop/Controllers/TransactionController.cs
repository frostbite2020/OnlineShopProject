using Application.Transactions.Commands.CheckoutTransaction;
/*using Application.Transactions.Commands.CreateTransaction;
*/using Application.Transactions.Queries.GetTransaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("transaction")]
    public class TransactionController : ApiControllerBase
    {
        /*[HttpGet]
        public async Task<GetTransactionVm> Get([FromQuery]GetTransactionQuery query)
        {
            return await Mediator.Send(query);
        } 

        [HttpPost]
        public async Task<int> Transaction([FromQuery]CreateTransactionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("checkout")]
        public async Task<int> Checkout([FromQuery]CheckoutTransactionCommand command)
        {
            return await Mediator.Send(command);
        }*/
    }
}
