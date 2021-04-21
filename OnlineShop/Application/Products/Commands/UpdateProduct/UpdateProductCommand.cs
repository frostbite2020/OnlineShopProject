using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int StockProduct { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productAsset = await _context.Products.FindAsync(request.Id);
            var stockAsset = await _context.Stocks.Where(x => x.ProductId == request.Id).FirstOrDefaultAsync();

            if (productAsset == null)
                throw new NotFoundException(nameof(Product), request.Id);

            if (request.Name != "")
                productAsset.Name = request.Name;
            if (request.Description != "")
                productAsset.Description = request.Description;
            if (request.ImageUrl != "")
                productAsset.ImageUrl = request.ImageUrl;
            if (request.Price != 0)
                productAsset.Price = request.Price;
            if (request.StockProduct != 0)
                stockAsset.StockProduct = request.StockProduct;

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
