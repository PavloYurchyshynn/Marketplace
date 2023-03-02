using Marketplace.Core.Entities;
using Marketplace.DataAccess.Persistence;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public class CustomerInfoRepository : BaseRepository<CustomerInfo>, ICustomerInfoRepository
    {
        public CustomerInfoRepository(Context context) : base(context) { }
    }
}
