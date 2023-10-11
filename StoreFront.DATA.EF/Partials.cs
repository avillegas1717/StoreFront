using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoreFront.DATA.EF.Models
{
    //internal class Partials
    //{
    //}

    #region VinylCollection
    [ModelMetadataType(typeof(VinylCollectionsMetadata))]
    public  partial class VinylCollection { }
    #endregion


    #region Genres
    [ModelMetadataType(typeof(GenresMetadata))]
    public partial class Genre { }
    #endregion


    #region Conditions
    [ModelMetadataType(typeof(ConditionsMetadata))]
    public partial class Condition { }
    #endregion
}
