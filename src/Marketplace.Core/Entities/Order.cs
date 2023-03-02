using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Order : BaseEntity
    {
        public CustomerInfo? CustomerInfo { get; set; }
        public ICollection<Product>? Product { get; set; }
        public ICollection<PaymentMethod>? PaymentMethod { get; set; }
        public ICollection<Promocode>? Promocode { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Status { get; set; }
    }
}
