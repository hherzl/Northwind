using System;

namespace Northwind.Core.DataLayer.DataContracts
{
    public class ProductDetail
    {
        public ProductDetail()
        {

        }

        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public String CategoryName { get; set; }

        public String CompanyName { get; set; }

        public String QuantityPerUnit { get; set; }

        public Decimal? UnitPrice { get; set; }
    }
}
