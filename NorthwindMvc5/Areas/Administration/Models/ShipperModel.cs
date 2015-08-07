using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class ShipperModel
    {
        public ShipperModel()
        {

        }

        public ShipperModel(Shipper entity)
        {
            ShipperID = entity.ShipperID;
            CompanyName = entity.CompanyName;
            Phone = entity.Phone;
        }

        [Key]
        public Int32? ShipperID { get; set; }

        [Display(Name = "Company name")]
        [Required]
        [StringLength(80)]
        public String CompanyName { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(40)]
        public String Phone { get; set; }
    }
}
