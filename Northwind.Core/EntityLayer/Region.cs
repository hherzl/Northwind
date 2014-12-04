using System;

namespace Northwind.Core.PocoLayer
{
    public class Region : Object
    {
        public Region()
        {

        }

        public Int32? RegionID { get; set; }

        public String RegionDescription { get; set; }
    }
}
