using System;

namespace Northwind.Core.DataLayer.DataContracts
{
    public class TenMostExpensiveProduct
    {
        public TenMostExpensiveProduct()
        {

        }

        public String TenMostExpensiveProducts { get; set; }

        public Decimal? UnitPrice { get; set; }
    }
}
