using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Carts.Queries.GetCart
{
    public class GetCartQueries : IRequest<GetCartVm>
    {
        public int UserPropertyId { get; set; }
    }

    public class GetCartQueriesHandler : IRequestHandler<GetCartQueries, GetCartVm>
    {
        private readonly IApplicationDbContext _context;

        public GetCartQueriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetCartVm> Handle(GetCartQueries request, CancellationToken cancellationToken)
        {
            if (!_context.UserProperties.Any(x => x.Id == request.UserPropertyId))
                throw new NotFoundException(nameof(UserProperty), request.UserPropertyId);

            var asset = _context.Carts
                .Where(x => x.UserPropertyId == request.UserPropertyId)
                .Include(x => x.Product)
                .ThenInclude(x => x.Store);

            var dto = asset.Select(x => new GetCartDto
            {
                Id = x.Id,
                ProductName = x.Product.Name,
                StoreName = x.Product.Store.Name,
                ProductPrice = ToRupiah(Convert.ToInt32(x.Product.Price)),
                Quantity = x.Quantity,
                TotalPrice = ToRupiah(x.TotalPrice)
            });

            var cartCount = _context.Carts
                .Where(x => x.UserPropertyId == request.UserPropertyId)
                .Count();

            var entity = new GetCartVm
            {
                Carts = await dto.ToListAsync(),
                CartCount = _context.Carts.Where(x => x.UserPropertyId == request.UserPropertyId).Count()
            };

            foreach (var price in asset)
            {
                var a = Convert.ToInt32(entity.TotalPriceCart);
                entity.TotalPriceCart = (a + price.TotalPrice).ToString();
            }

            entity.TotalPriceCart = ToRupiah(Convert.ToInt32(entity.TotalPriceCart));

            return entity;
        }

        private static string ToRupiah(int price)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", price);
        }
    }
}
