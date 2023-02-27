﻿using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CommentsId { get; set; }
    }
}
