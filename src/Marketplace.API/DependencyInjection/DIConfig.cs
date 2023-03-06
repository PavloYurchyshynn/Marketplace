using Marketplace.DataAccess.Persistence;
using Marketplace.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MarketplaceContext>(options => options.UseSqlServer(connection));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromocodeRepository, PromocodeRepository>();
        }
    }
}
