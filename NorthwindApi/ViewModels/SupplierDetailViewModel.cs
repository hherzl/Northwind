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
        }

        [Key]
        public Int32? SupplierID { get; set; }

        public String CompanyName { get; set; }
    }
}
