using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MarketplaceContext context) : base(context) { }
    }
}
