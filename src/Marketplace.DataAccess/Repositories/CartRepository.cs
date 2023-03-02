using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(Context context) : base(context) { }
    }
}
