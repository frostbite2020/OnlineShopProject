﻿using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Admins.Queries.Sellers.GetNewSeller
{
    public class GetNewSellerQuery : IRequest<GetNewSellerVm>
    {
    }

    public class GetNewSellerQUeryHandler : IRequestHandler<GetNewSellerQuery, GetNewSellerVm>
    {
        private readonly IApplicationDbContext _context;

        public GetNewSellerQUeryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetNewSellerVm> Handle(GetNewSellerQuery request, CancellationToken cancellationToken)
        {
            var asset = _context.NewSellers
                .Include(x => x.UserProperty);

            var dto = asset.Select(x => new GetNewSellerDto
            {
                Id = x.Id,
                FullName = x.UserProperty.FirstName + " " + x.UserProperty.LastName,
                StoreName = x.StoreName,
                Email = x.UserProperty.Email,
                NPWP = x.NPWP,
                IdCardNumber = x.IdCardNumber,
                DateRequest = x.DateRequest.ToString("dd")
            });

            return new GetNewSellerVm
            {
                Lists = await dto.ToListAsync()
            };
        }
    }
}
