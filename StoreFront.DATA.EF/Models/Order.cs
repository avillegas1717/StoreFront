using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderCollections = new HashSet<OrderCollection>();
        }

        public int OrderId { get; set; }
        public string? ShopperId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? ShipToName { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipState { get; set; }
        public string? ShipZip { get; set; }
        public string? ShipEmail { get; set; }

        public virtual ShopperDetail? Shopper { get; set; }
        public virtual ICollection<OrderCollection> OrderCollections { get; set; }
    }
}
