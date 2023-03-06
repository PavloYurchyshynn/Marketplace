using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(MarketplaceContext context) : base(context) { }
    }
}
