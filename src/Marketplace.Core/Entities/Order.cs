using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Order : BaseEntity
    {
        public string DeliveryAddress { get; set; }
        public Guid ProductId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid PromocodeId { get; set; }
        public string Status { get; set; }
        public Guid CustomerInfoId { get; set; }
    }
}
