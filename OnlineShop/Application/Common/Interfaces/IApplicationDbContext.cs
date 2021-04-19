using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<UserProperty> UserProperties { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionIndex> TransactionIndexs { get; set; }
        DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
