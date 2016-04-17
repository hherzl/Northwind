using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class SupplierModel
    {
        public SupplierModel()
        {

        }

        public SupplierModel(Supplier entity)
        {
            SupplierID = entity.SupplierID;
            CompanyName = entity.CompanyName;
            ContactName = entity.ContactName;
            ContactTitle = entity.ContactTitle;
            Address = entity.Address;
            City = entity.City;
            Region = entity.Region;
            PostalCode = entity.PostalCode;
            Country = entity.Country;
            Phone = entity.Phone;
            Fax = entity.Fax;
        }

        [Key]
        public Int32? SupplierID { get; set; }

        [Display(Name = "CompanyName", ResourceType = typeof(SupplierResource))]
        [Required(ErrorMessageResourceName = "CompanyNameRequired", ErrorMessageResourceType = typeof(SupplierResource))]
        public String CompanyName { get; set; }

        [Display(Name = "ContactName", ResourceType = typeof(SupplierResource))]
        public String ContactName { get; set; }

        [Display(Name = "ContactTitle", ResourceType = typeof(SupplierResource))]
        public String ContactTitle { get; set; }

        [Display(Name = "Address", ResourceType = typeof(SupplierResource))]
        public String Address { get; set; }

        [Display(Name = "City", ResourceType = typeof(SupplierResource))]
        public String City { get; set; }

        [Display(Name = "Region", ResourceType = typeof(SupplierResource))]
        public String Region { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(SupplierResource))]
        public String PostalCode { get; set; }

        [Display(Name = "Country", ResourceType = typeof(SupplierResource))]
        public String Country { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(SupplierResource))]
        public String Phone { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(SupplierResource))]
        public String Fax { get; set; }

        [Display(Name = "HomePage", ResourceType = typeof(SupplierResource))]
        public String HomePage { get; set; }
    }
}
