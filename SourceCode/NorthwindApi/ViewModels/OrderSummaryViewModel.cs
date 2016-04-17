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
            CustomerID = entity.CustomerID;
            CustomerName = entity.CustomerName;
            EmployeeID = entity.EmployeeID;
            EmployeeName = entity.EmployeeName;
            ShipperID = entity.ShipperID;
            ShipperName = entity.ShipperName;
            Lines = entity.Lines;
            Total = entity.Total;
        }

        [Key]
        public Int32? OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public String CustomerID { get; set; }

        public String CustomerName { get; set; }

        public Int32? EmployeeID { get; set; }

        public String EmployeeName { get; set; }

        public Int32? ShipperID { get; set; }

        public String ShipperName { get; set; }

        public Int32 Lines { get; set; }

        public Decimal? Total { get; set; }
    }
}
