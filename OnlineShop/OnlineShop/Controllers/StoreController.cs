using Application.Stores.Commands.CreateStore;
using Application.Stores.Commands.DeleteStore;
using Application.Stores.Commands.UpdateStore;
using Application.Stores.Queries.GetAllStore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("store")]
    public class StoreController : ApiControllerBase
    {
        [HttpGet]
        public async Task<GetAllStoreVm> GetAll()
        {
            return await Mediator.Send(new GetAllStoreQueries());
        }

        [HttpPost]
        public async Task<int> Add(CreateStoreCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update (int id, UpdateStoreCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete (int id)
        {
            return await Mediator.Send(new DeleteStoreCommand { Id = id });
        }
    }
}
