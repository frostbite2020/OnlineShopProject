using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Transactions.Commands.CheckoutTransaction
{
    public class CheckoutTransactionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class CheckoutTransactionCommandHandler : IRequestHandler<CheckoutTransactionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CheckoutTransactionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CheckoutTransactionCommand request, CancellationToken cancellationToken)
        {
            if (!_context.TransactionIndexs.Any(x => x.Id == request.Id))
                throw new NotFoundException(nameof(Transaction), request.Id);
            
            var asset = _context.Transactions
                .Where(x => x.TransactionIndexId == request.Id);

            foreach(var status in asset)
            {
                status.Status = Status.OnProccess;
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
