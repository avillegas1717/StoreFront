using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class OrderCollection
    {
        public int OrderCollectionId { get; set; }
        public int CollectionId { get; set; }
        public int OrderId { get; set; }
        public short? Quantity { get; set; }
        public decimal? CollectionPrice { get; set; }

        public virtual VinylCollection Collection { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
