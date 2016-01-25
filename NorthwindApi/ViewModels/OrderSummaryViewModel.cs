using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.DataLayer.DataContracts;

namespace NorthwindApi.ViewModels
{
    public class OrderSummaryViewModel
    {
        public OrderSummaryViewModel()
        {

        }

        public OrderSummaryViewModel(OrderSummary entity)
        {
            OrderID = entity.OrderID;
            OrderDate = entity.OrderDate;
            Customer = entity.Customer;
            Employee = entity.Employee;
            Shipper = entity.Shipper;
            Lines = entity.Lines;
            Total = entity.Total;
        }

        [Key]
        public Int32? OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public String Customer { get; set; }

        public String Employee { get; set; }

        public String Shipper { get; set; }

        public Int32 Lines { get; set; }

        public Decimal? Total { get; set; }
    }
}
