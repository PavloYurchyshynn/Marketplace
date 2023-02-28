using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string? Message { get; set; }
        public Guid UserId { get; set; }
        public DateTime SendDate { get; set; }
    }
}
