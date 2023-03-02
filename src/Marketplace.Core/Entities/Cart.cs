using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Cart : BaseEntity
    {
        public ICollection<Product>? Products { get; set; }
    }
}
