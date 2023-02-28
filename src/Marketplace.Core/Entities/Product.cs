using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Product : BaseEntity
    {
        public Comment? Comment;
        public Category? Category;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
    }
}
