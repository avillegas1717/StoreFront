using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Genre
    {
        public Genre()
        {
            VinylCollections = new HashSet<VinylCollection>();
        }

        public int GenreId { get; set; }
        public string? GenreName { get; set; }
        public string? GenreDescription { get; set; }

        public virtual ICollection<VinylCollection> VinylCollections { get; set; }
    }
}
