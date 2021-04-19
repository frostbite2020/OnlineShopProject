using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }

    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, int>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateStoreCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = new Store
            {
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                Contact = request.Contact
            };

            _context.Stores.Add(entity);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
