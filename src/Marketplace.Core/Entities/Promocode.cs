﻿using Marketplace.Core.Common;

namespace Marketplace.Core.Entities
{
    public class Promocode : BaseEntity
    {
        public string? Code { get; set; }
        public int DiscountPercent { get; set; }
    }
}
