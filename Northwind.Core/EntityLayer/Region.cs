using System;

namespace Northwind.Core.EntityLayer
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
