using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class CustomerInfo : BaseEntity
    {
        public int Number { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LaseUpdateDate { get; set; }
    }
}
