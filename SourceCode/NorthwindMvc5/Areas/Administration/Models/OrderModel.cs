using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class OrderModel
    {
        public OrderModel()
        {

        }

        public OrderModel(Order entity)
        {
            OrderID = entity.OrderID;
            CustomerID = entity.CustomerID;
            EmployeeID = entity.EmployeeID;
            OrderDate = entity.OrderDate;
            RequiredDate = entity.RequiredDate;
            ShippedDate = entity.ShippedDate;
            ShipVia = entity.ShipVia;
            Freight = entity.Freight;
            ShipName = entity.ShipName;
            ShipAddress = entity.ShipAddress;
            ShipCity = entity.ShipCity;
            ShipRegion = entity.ShipRegion;
            ShipPostalCode = entity.ShipPostalCode;
            ShipCountry = entity.ShipCountry;

            Entity = entity;
        }

        [Key]
        public Int32? OrderID { get; set; }

        public String CustomerID { get; set; }

        public Int32? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public Int32? ShipVia { get; set; }

        public Decimal? Freight { get; set; }

        public String ShipName { get; set; }

        public String ShipAddress { get; set; }

        public String ShipCity { get; set; }

        public String ShipRegion { get; set; }

        public String ShipPostalCode { get; set; }

        public String ShipCountry { get; set; }

        public Order Entity { get; set; }
    }
}
