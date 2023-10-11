using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA.EF.Models
{
    //internal class Metadata
    //{
    //}

    public class VinylCollectionsMetadata
    {
        public int CollectionID { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DisplayFormat(ApplyFormatInEditMode = false,
            DataFormatString = "{0:c}")]
        [Range(0, double.MaxValue)]
        public decimal CollectionPrice { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Must not exceed 500 characters")]
        [UIHint("MultiLineText")]
        public string CollectionDescription { get; set; }

        [Required]
        [Display(Name = "Units In Stock")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:n0}")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Discontinued")]
        public bool IsDiscontinued { get; set; }

        public string? CollectionImage { get; set; }

    }

    public class GenresMetadata
    {
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string GenreName { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Must not exceed 500 characters")]
        [UIHint("MultiLineText")]
        public string GenreDescription { get; set; }
    }

    public class ConditionsMetadata
    {
        public int ConditionID { get; set; }

        [Required]
        [Display(Name = "Condition")]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string ConditionName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Must not exceed 500 characters")]
        [UIHint("MultiLineText")]
        public string ConditionDescription { get; set; }
    }


}//end namespace
