using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(MarketplaceContext context) : base(context) { }
    }
}
