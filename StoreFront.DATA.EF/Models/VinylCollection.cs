using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class VinylCollection
    {
        public VinylCollection()
        {
            OrderCollections = new HashSet<OrderCollection>();
        }

        public int CollectionId { get; set; }
        public int GenreId { get; set; }
        public decimal? CollectionPrice { get; set; }
        public string? CollectionDescription { get; set; }
        public short UnitsInStock { get; set; }
        public bool? IsDiscontinued { get; set; }
        public string? CollectionImage { get; set; }
        public int ConditionId { get; set; }

        public virtual Condition Condition { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<OrderCollection> OrderCollections { get; set; }
    }
}
