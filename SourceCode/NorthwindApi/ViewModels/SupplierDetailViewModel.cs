using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.ViewModels
{
    public class SupplierDetailViewModel
    {
        public SupplierDetailViewModel()
        {

        }

        public SupplierDetailViewModel(Supplier entity)
        {
            SupplierID = entity.SupplierID;
            CompanyName = entity.CompanyName;
            ContactName = entity.ContactName;
            Country = entity.Country;
            City = entity.City;
        }

        [Key]
        public Int32? SupplierID { get; set; }

        public String CompanyName { get; set; }

        public String ContactName { get; set; }

        public String Country { get; set; }

        public String City { get; set; }
    }
}
