using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

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

        public ProductModel(ProductDetail entity)
        {
            ProductID = entity.ProductID;
            ProductName = entity.ProductName;
            SupplierID = entity.SupplierID;
            CategoryName = entity.CategoryName;
            CompanyName = entity.CompanyName;
            CategoryID = entity.CategoryID;
            QuantityPerUnit = entity.QuantityPerUnit;
            UnitPrice = entity.UnitPrice;
            Discontinued = entity.Discontinued;
        }

        [Key]
        public Int32? ProductID { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(ProductResource))]
        [Required(ErrorMessageResourceName = "ProductNameRequired", ErrorMessageResourceType = typeof(ProductResource))]
        [StringLength(80, ErrorMessageResourceName = "ProductNameStringLength", ErrorMessageResourceType = typeof(ProductResource))]
        public String ProductName { get; set; }

        [Display(Name = "SupplierID", ResourceType = typeof(ProductResource))]
        public Int32? SupplierID { get; set; }

        [Display(Name = "CategoryID", ResourceType = typeof(ProductResource))]
        public Int32? CategoryID { get; set; }

        [Display(Name = "QuantityPerUnit", ResourceType = typeof(ProductResource))]
        [StringLength(40, ErrorMessageResourceName = "QuantityPerUnitStringLength", ErrorMessageResourceType = typeof(ProductResource))]
        public String QuantityPerUnit { get; set; }

        [Display(Name = "UnitPrice", ResourceType = typeof(ProductResource))]
        public Decimal? UnitPrice { get; set; }

        [Display(Name = "UnitsInStock", ResourceType = typeof(ProductResource))]
        public Int16? UnitsInStock { get; set; }

        [Display(Name = "UnitsOnOrder", ResourceType = typeof(ProductResource))]
        public Int16? UnitsOnOrder { get; set; }

        [Display(Name = "ReorderLevel", ResourceType = typeof(ProductResource))]
        public Int16? ReorderLevel { get; set; }

        [Display(Name = "Discontinued", ResourceType = typeof(ProductResource))]
        [Required(ErrorMessageResourceName = "DiscontinuedRequired", ErrorMessageResourceType = typeof(ProductResource))]
        public Boolean? Discontinued { get; set; }

        [Display(Name = "CompanyName", ResourceType = typeof(ProductResource))]
        public String CompanyName { get; set; }

        [Display(Name = "CategoryName", ResourceType = typeof(ProductResource))]
        public String CategoryName { get; set; }
    }
}
