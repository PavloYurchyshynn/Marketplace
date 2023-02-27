using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public int ZipCode { get; set; }
    }
}
