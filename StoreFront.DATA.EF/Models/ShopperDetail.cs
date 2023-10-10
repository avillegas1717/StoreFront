using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class ShopperDetail
    {
        public ShopperDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string ShopperId { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
