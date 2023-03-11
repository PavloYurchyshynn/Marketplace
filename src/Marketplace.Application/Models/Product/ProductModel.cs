using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Application.Models.Product
{
    public class ProductModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public int Rate { get; set; }
    }
}
