using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Cart : BaseEntity
    {
        public ICollection<CartItem>? CartItems { get; set; }
        public string? Status { get; set; }
    }
}
