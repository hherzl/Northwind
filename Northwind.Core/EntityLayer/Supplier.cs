using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.EntityLayer
{
    public class Supplier : Object
    {
        public Supplier()
        {

        }

        public Supplier(Int32? supplierID)
        {
            SupplierID = supplierID;
        }

        public Int32? SupplierID { get; set; }

        public String CompanyName { get; set; }

        public String ContactName { get; set; }

        public String ContactTitle { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public String Region { get; set; }

        public String PostalCode { get; set; }

        public String Country { get; set; }

        public String Phone { get; set; }

        public String Fax { get; set; }

        public String HomePage { get; set; }

        public virtual Collection<Product> Products { get; set; }
    }
}
