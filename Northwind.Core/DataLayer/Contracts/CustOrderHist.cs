using System;

namespace Northwind.Core.DataLayer.Contracts
{
    public class CustOrderHist
    {
        public CustOrderHist()
        {

        }

        public String ProductName { get; set; }

        public Int32? Total { get; set; }
    }
}
