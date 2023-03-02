using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Category : BaseEntity
    {
        public Product? Product { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}
