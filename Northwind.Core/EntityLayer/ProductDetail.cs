using System;

namespace Northwind.Core.PocoLayer
{
    public class ProductDetail
    {
        public Int32? ProductID { get; set; }

        public String ProductName { get; set; }

        public String CategoryName { get; set; }

        public String CompanyName { get; set; }

        public String QuantityPerUnit { get; set; }

        public Decimal? UnitPrice { get; set; }
    }
}
