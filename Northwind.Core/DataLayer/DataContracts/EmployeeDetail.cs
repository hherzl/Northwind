using System;

namespace Northwind.Core.DataLayer.DataContracts
{
    public class EmployeeDetail
    {
        public EmployeeDetail()
        {

        }

        public Int32? EmployeeID { get; set; }

        public String FullName { get; set; }

        public String Title { get; set; }

        public String TitleOfCourtesy { get; set; }
    }
}
