using System;

namespace Northwind.Core.DataLayer.Contracts
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
