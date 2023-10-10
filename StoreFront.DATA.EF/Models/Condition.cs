using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Condition
    {
        public Condition()
        {
            VinylCollections = new HashSet<VinylCollection>();
        }

        public int ConditionId { get; set; }
        public string? ConditionName { get; set; }
        public string? ConditionDescripton { get; set; }

        public virtual ICollection<VinylCollection> VinylCollections { get; set; }
    }
}
