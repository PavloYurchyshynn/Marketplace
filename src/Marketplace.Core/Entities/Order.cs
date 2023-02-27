using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Order : BaseEntity
    {
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
    }
}
