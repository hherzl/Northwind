using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.EntityLayer
{
    public class Product : Object
    {
        public Product()
        {

        }

        public Product(Int32? productID)
        {
            ProductID = productID;
        }

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

        public virtual Category FkProductsCategories { get; set; }

        public virtual Supplier FkProductsSuppliers { get; set; }
    }
}
