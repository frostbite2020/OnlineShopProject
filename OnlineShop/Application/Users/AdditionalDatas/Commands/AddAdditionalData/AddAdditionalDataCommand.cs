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

namespace Application.Users.AdditionalDatas.Commands.AddAdditionalData
{
    public class AddAdditionalDataCommand : IRequest<string>
    {
        public int TransactionIndexId { get; set; }
        public string ShippingAddress { get; set; }
        public string Note { get; set; }
    }

    public class AddAdditionalDataCommandHandler : IRequestHandler<AddAdditionalDataCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public AddAdditionalDataCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(AddAdditionalDataCommand request, CancellationToken cancellationToken)
        {
            if (!_context.TransactionIndexs.Any(x => x.Id == request.TransactionIndexId))
                throw new NotFoundException(nameof(TransactionIndex), request.TransactionIndexId);

            var entity = new AdditionalData
            {
                TransactionIndexId = request.TransactionIndexId,
                ShippingAddress = request.ShippingAddress,
                Note = request.Note
            };

            _context.AdditionalDatas.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return "Additional data has been created";
        }
    }
}
