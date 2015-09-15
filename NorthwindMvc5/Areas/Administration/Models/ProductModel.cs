using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(Product entity)
        {
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            SupplierID = entity.SupplierID;
            CategoryID = entity.CategoryID;
            QuantityPerUnit = entity.QuantityPerUnit;
            UnitPrice = entity.UnitPrice;
            UnitsInStock = entity.UnitsInStock;
            UnitsOnOrder = entity.UnitsOnOrder;
            ReorderLevel = entity.ReorderLevel;
            Discontinued = entity.Discontinued;
        }

        [Key]
        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public Int32? SupplierID { get; set; }

        public Int32? CategoryID { get; set; }

        public String QuantityPerUnit { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Int16? UnitsInStock { get; set; }

        public Int16? UnitsOnOrder { get; set; }

        public Int16? ReorderLevel { get; set; }

        public Boolean? Discontinued { get; set; }
    }
}
