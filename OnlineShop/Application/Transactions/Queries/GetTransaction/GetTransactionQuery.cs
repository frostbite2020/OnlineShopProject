/*using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionQuery : IRequest<GetTransactionVm>
    {
        public int UserPropertyId { get; set; }
    }

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, GetTransactionVm>
    {
        private readonly IApplicationDbContext _context;

        public GetTransactionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetTransactionVm> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            if (!_context.UserProperties.Any(x => x.Id == request.UserPropertyId))
                throw new NotFoundException(nameof(UserProperty), request.UserPropertyId);

            //Get Transaction Detail
            var transactionAsset = _context.Transactions
                .Include(x => x.Product)
                .ThenInclude(x => x.Store);

            var dto = transactionAsset.Select(x => new GetTransactionDto
            {
                Id = x.Id,
                TransactionIndexId = x.TransactionIndexId,
                StoreName = x.Product.Store.Name,
                ProductName = x.Product.Name,
                ProductImage = x.Product.ImageUrl,
                ProductCount = x.Quantity,
                ProductPrice = ToRupiah(Convert.ToInt32(x.Product.Price)),
                TotalProductPrice = ToRupiah(x.TotalPrice),
                Status = x.Status
            });

            //Get Enumerable Transactions By Index
            var index = _context.TransactionIndexs
                .Where(x => x.UserPropertyId == request.UserPropertyId);

            var indexDto = index.Select(x => new GetTransactionIndexDto
            {
                Id = x.Id,
                Lists = dto.Where(a => a.TransactionIndexId == x.Id).ToList(),
                TotalTransactionPrice = ToRupiah(x.TotalTransactionPrice)
            });

            return new GetTransactionVm
            {
                Transactions = await indexDto.ToListAsync()
            };
        }

        private static string ToRupiah(int price)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", price);
        }
    }
}
*/