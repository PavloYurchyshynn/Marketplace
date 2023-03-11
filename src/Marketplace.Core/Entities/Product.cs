using Marketplace.Core.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Core.Entities
{
    public class Product : BaseEntity
    {
        public Order? Order { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<Category>? Category { get; set; }
        public ICollection<Comment>? Comment { get; set; }

        public Guid SellerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public int Rate { get; set; }
    }
}
