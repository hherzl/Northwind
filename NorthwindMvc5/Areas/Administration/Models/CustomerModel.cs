using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {

        }

        public CustomerModel(Customer entity)
        {
            CustomerID = entity.CustomerID;
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
        public String CustomerID { get; set; }

        [Display(Name = "CompanyName", ResourceType = typeof(CustomerResource))]
        public String CompanyName { get; set; }

        [Display(Name = "ContactName", ResourceType = typeof(CustomerResource))]
        public String ContactName { get; set; }

        [Display(Name = "ContactTitle", ResourceType = typeof(CustomerResource))]
        public String ContactTitle { get; set; }

        [Display(Name = "Address", ResourceType = typeof(CustomerResource))]
        public String Address { get; set; }

        [Display(Name = "City", ResourceType = typeof(CustomerResource))]
        public String City { get; set; }

        [Display(Name = "Region", ResourceType = typeof(CustomerResource))]
        public String Region { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(CustomerResource))]
        public String PostalCode { get; set; }

        [Display(Name = "Country", ResourceType = typeof(CustomerResource))]
        public String Country { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(CustomerResource))]
        public String Phone { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(CustomerResource))]
        public String Fax { get; set; }
    }
}
