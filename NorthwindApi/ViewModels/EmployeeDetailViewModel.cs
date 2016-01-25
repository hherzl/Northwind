using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public EmployeeDetailViewModel()
        {

        }

        public EmployeeDetailViewModel(Employee item)
        {
            EmployeeID = item.EmployeeID;
            FullName = item.FirstName + " " + item.LastName;
            Title = item.Title;
            TitleOfCourtesy = item.TitleOfCourtesy;
        }

        [Key]
        public Int32? EmployeeID { get; set; }

        public String FullName { get; set; }

        public String Title { get; set; }

        public String TitleOfCourtesy { get; set; }
    }
}
