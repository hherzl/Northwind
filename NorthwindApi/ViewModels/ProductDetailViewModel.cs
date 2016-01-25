using System;
using Northwind.Core.DataLayer.DataContracts;

namespace NorthwindApi.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {

        }

        public ProductDetailViewModel(ProductDetail entity)
        {
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            SupplierID = entity.SupplierID;
            CompanyName = entity.CompanyName;
            CategoryID = entity.CategoryID;
            CategoryName = entity.CategoryName;
            QuantityPerUnit = entity.QuantityPerUnit;
            UnitPrice = entity.UnitPrice;
            Discontinued = entity.Discontinued;
        }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Int32? SupplierID { get; set; }

        public String CompanyName { get; set; }

        public Int32? CategoryID { get; set; }

        public String CategoryName { get; set; }

        public String QuantityPerUnit { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Boolean? Discontinued { get; set; }
    }
}
