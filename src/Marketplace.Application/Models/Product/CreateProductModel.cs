using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Application.Models.Product
{
    public class CreateProductModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
    }
}
