using System;

namespace Northwind.Core.EntityLayer
{
    public class Region : Object
    {
        public Region()
        {

        }

        public Region(Int32? regionID)
        {
            RegionID = regionID;
        }

        public Int32? RegionID { get; set; }

        public String RegionDescription { get; set; }
    }
}
