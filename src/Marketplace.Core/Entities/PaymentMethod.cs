using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public Order? Order { get; set; }
        public string? Name { get; set; }
    }
}
