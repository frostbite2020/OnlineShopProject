using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.AddNewProduct
{
    public class AddNewProductCommand : IRequest<int>
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int StockProduct { get; set; }
    }

    public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public AddNewProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                StoreId = request.StoreId
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var stock = new Stock
            {
                StockProduct = request.StockProduct,
                ProductId = entity.Id
            };

            _context.Stocks.Add(stock);

            return await _context.SaveChangesAsync(cancellationToken);
   
        }
    }
}
