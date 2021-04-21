using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks{ get; set; }
        public DbSet<UserProperty> UserProperties { get; set; }
        public DbSet<CartIndex> CartIndexs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionIndex> TransactionIndexs { get; set; }
        public DbSet<NewSeller> NewSellers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
