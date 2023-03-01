using Microsoft.EntityFrameworkCore;
// using Marketplace.Core.Entities;

namespace Marketplace.DataAccess.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        /*public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Address> Address { get; set; }*/
    }
}
