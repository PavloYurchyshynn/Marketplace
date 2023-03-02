using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class CustomerInfo : BaseEntity
    {
        public Guid User_Id { get; set; }
        public ICollection<Order>? Order { get; set; }
        public Address? Address { get; set; }
        public int Number { get; set; }
        public DateTime LaseUpdateDate { get; set; }
    }
}
