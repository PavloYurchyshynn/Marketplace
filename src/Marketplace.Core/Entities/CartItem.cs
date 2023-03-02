using Marketplace.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }
    }
}
