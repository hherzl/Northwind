using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

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

        [Display(Name = "CompanyName", ResourceType = typeof(ShipperResource))]
        [Required(ErrorMessageResourceName = "CompanyNameRequired", ErrorMessageResourceType = typeof(ShipperResource))]
        [StringLength(80, ErrorMessageResourceName = "CompanyNameStringLength", ErrorMessageResourceType = typeof(ShipperResource))]
        public String CompanyName { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(ShipperResource))]
        [StringLength(40, ErrorMessageResourceName = "PhoneStringLength", ErrorMessageResourceType = typeof(ShipperResource))]
        public String Phone { get; set; }
    }
}
