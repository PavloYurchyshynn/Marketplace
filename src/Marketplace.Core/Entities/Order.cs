using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Order : BaseEntity
    {
        public Promocode? Promocode;
        public PaymentMethod? PaymentMethod;
        public CustomerInfo? CustomerInfo;
        public Product? Product;
        public string? DeliveryAddress { get; set; }
        public string? Status { get; set; }
    }
}
