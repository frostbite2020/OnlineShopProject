using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int UserPropertyId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var price = await _context.Products
                .Where(x => x.Id == request.ProductId)
                .FirstOrDefaultAsync();

            var entity = new Cart
            {
                ProductId = request.ProductId,
                UserPropertyId = request.UserPropertyId,
                Quantity = request.Quantity,
                TotalPrice = Convert.ToInt32(price.Price) * request.Quantity
            };

            _context.Carts.Add(entity);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
