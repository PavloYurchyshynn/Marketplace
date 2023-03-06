using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class PromocodeRepository : BaseRepository<Promocode>, IPromocodeRepository
    {
        public PromocodeRepository(MarketplaceContext context) : base(context) { }
    }
}
