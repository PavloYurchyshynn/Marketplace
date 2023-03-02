using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Comment : BaseEntity
    {
        public Guid User_Id { get; set; }
        public Product? Product { get; set; }
        public string? Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
