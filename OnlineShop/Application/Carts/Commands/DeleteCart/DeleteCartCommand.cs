using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Carts.Commands.DeleteCart
{
    public class DeleteCartCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            if(!_context.Carts.Any(x => x.Id == request.Id))
                throw new NotFoundException(nameof(Cart), request.Id);

            var entity = await _context.Carts.FindAsync(request.Id);

            _context.Carts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return "Cart id {request.Id} Terhapus!";
        }
    }
}
