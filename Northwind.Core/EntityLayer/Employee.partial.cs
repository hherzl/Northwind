using System;

namespace Northwind.Core.EntityLayer
{
    public partial class Employee
    {
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
