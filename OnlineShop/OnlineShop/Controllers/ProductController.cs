using Application.Products.Commands.AddNewProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetAllProduct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("product")]
    public class ProductController : ApiControllerBase
    {
        [HttpGet]
        public async Task<GetAllProductVm> GetAll([FromQuery]GetAllProductQueries query)
        {
            return await Mediator.Send(query);
        }
        [HttpPost]
        public async Task<int> Add(AddNewProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeleteProductCommand { Id = id });
        }
    }
}
