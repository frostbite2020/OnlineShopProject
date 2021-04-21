/*using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public int UserPropertyId { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTransactionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            if (!_context.UserProperties.Any(x => x.Id == request.UserPropertyId))
                throw new NotFoundException(nameof(UserProperty), request.UserPropertyId);

            //Create TransactionIndex
            var transactionIndexEntity = new TransactionIndex
            {
                UserPropertyId = request.UserPropertyId,
            };

            _context.TransactionIndexs.Add(transactionIndexEntity);
            await _context.SaveChangesAsync(cancellationToken);

            //Moving Cart to Transaction Method
            var count = _context.Carts
                .Where(x => x.UserPropertyId == request.UserPropertyId)
                .Count();

            var index = _context.TransactionIndexs
                .Where(x => x.UserPropertyId == request.UserPropertyId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            //Loop for multiple data
            while (count > 0)
            {
                //Getting Cart Asset
                var assetCart = await _context.Carts
                    .Where(x => x.UserPropertyId == request.UserPropertyId)
                    .FirstOrDefaultAsync();

                //Add entity Transaction Table
                var transactionEntity = new Transaction
                {
                    ProductId = assetCart.ProductId,
                    Quantity = assetCart.Quantity,
                    TotalPrice = assetCart.TotalPrice,
                    Status = Status.WaitingForPayment,
                    TransactionIndexId = index.Id
                };

                //Add Total Transaction Price to TransactionIndex Table
                var a = transactionIndexEntity.TotalTransactionPrice;
                transactionIndexEntity.TotalTransactionPrice = a + assetCart.TotalPrice;

                _context.Transactions.Add(transactionEntity);

                //Removing Cart
                _context.Carts.Remove(assetCart);

                await _context.SaveChangesAsync(cancellationToken);

                count--;
            }

            return 1;
        }
    }
}
*/