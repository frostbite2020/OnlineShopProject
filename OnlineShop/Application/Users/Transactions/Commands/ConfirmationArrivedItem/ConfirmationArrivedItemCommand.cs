﻿using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Transactions.Commands.ConfirmationArrivedItem
{
    public class ConfirmationArrivedItemCommand : IRequest<string>
    {
        public int TranscationIndexId { get; set; }
    }

    public class ConfirmationArrivedItemCommandHandler : IRequestHandler<ConfirmationArrivedItemCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public ConfirmationArrivedItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(ConfirmationArrivedItemCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now;

            if (!_context.TransactionIndexs.Any(x => x.Id == request.TranscationIndexId))
                throw new NotFoundException(nameof(TransactionIndex), request.TranscationIndexId);

            var transactionIndexAsset = await _context.TransactionIndexs.FindAsync(request.TranscationIndexId);

            if(transactionIndexAsset.Status == Status.Arrived)
            {
                transactionIndexAsset.Status = Status.ItemReceived;

                //Add new Purchase history index
                var additionalDataAsset = _context.AdditionalDatas
                    .Where(x => x.TransactionIndexId == request.TranscationIndexId)
                    .FirstOrDefault();

                var entity = new PurchaseHistoryIndex
                {
                    UserPropertyId = transactionIndexAsset.UserPropertyId,
                    PaymentId = transactionIndexAsset.PaymentId,
                    ShippingId = transactionIndexAsset.ShipmentId,
                    StoreId = transactionIndexAsset.StoreId,
                    DateTransactionDone = now,
                    Note = additionalDataAsset.Note,
                    ShippingAddress = additionalDataAsset.ShippingAddress,
                    Status = transactionIndexAsset.Status
                };

                _context.PurchaseHistoryIndexs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //Get transaction asset
                var transactionAsset = _context.Transactions
                    .Where(x => x.TransactionIndexId == request.TranscationIndexId);

                foreach(var data in transactionAsset)
                {
                    var productAsset = _context.Products
                        .Where(x => x.Id == data.ProductId)
                        .FirstOrDefault();

                    var purchaseHistoryEntity = new PurchaseHistory
                    {
                        ProductId = productAsset.Id,
                        ProductName = productAsset.Name,
                        ImageUrl = productAsset.Description,
                        UnitPrice = productAsset.Price,
                        Quantity = data.Quantity,
                        TotalPrice = data.TotalPrice,
                        PurchaseHistoryIndexId = entity.Id
                    };

                    _context.PurchaseHistories.Add(purchaseHistoryEntity);

                }

                _context.TransactionIndexs.Remove(transactionIndexAsset);

                await _context.SaveChangesAsync(cancellationToken);

                return "Item received";
            }

            return "Item still not arrive";
        }
    }
}
