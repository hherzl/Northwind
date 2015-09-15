using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

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
            RegionDescription = entity.RegionDescription;
        }

        [Key]
        public Int32? RegionID { get; set; }

        public String RegionDescription { get; set; }
    }
}
