using Microsoft.EntityFrameworkCore;
using Marketplace.Core.Entities;

namespace Marketplace.DataAccess.Persistence
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
