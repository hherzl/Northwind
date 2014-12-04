using System;
using System.Collections.ObjectModel;

namespace Northwind.Core.PocoLayer
{
    public class Category : Object
    {
        public Category()
        {

        }

        public Int32? CategoryID { get; set; }

        public String CategoryName { get; set; }

        public String Description { get; set; }

        public Byte[] Picture { get; set; }

        public virtual Collection<Product> Products { get; set; }
    }
}
