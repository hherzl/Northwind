using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class RegionModel
    {
        public RegionModel()
        {

        }

        public RegionModel(Region entity)
        {
            RegionID = entity.RegionID;
            RegionDescription = entity.RegionDescription.Trim();
        }

        [Key]
        [Display(Name = "RegionID", ResourceType = typeof(RegionResource))]
        [Required(ErrorMessageResourceName = "RegionIDRequired", ErrorMessageResourceType = typeof(RegionResource))]
        public Int32? RegionID { get; set; }

        [Display(Name = "RegionDescription", ResourceType = typeof(RegionResource))]
        [Required(ErrorMessageResourceName = "RegionDescriptionRequired", ErrorMessageResourceType = typeof(RegionResource))]
        [StringLength(80, ErrorMessageResourceName = "RegionDescriptionStringLength", ErrorMessageResourceType = typeof(RegionResource))]
        public String RegionDescription { get; set; }
    }
}
