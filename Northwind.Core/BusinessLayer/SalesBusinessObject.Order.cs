using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<OrderSummary>> GetOrderSummaries(String customerID, Int32? employeeID, Int32? shipperID)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .OrderRepository
                    .GetSummaries(customerID, employeeID, shipperID)
                    .OrderByDescending(item => item.OrderDate);
            });
        }

        public async Task<Order> GetOrder(Order entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .OrderRepository
                    .Get(new Order(entity.OrderID));
            });
        }

        public async Task<Order> CreateOrder(Order entity)
        {
            var header = new Order();

            using (var transaction = Uow.GetTransaction())
            {
                try
                {
                    header.CustomerID = entity.CustomerID;
                    header.EmployeeID = entity.EmployeeID;
                    header.OrderDate = entity.OrderDate;
                    header.RequiredDate = entity.RequiredDate;
                    header.ShipVia = entity.ShipVia;
                    header.Freight = entity.Freight;
                    header.ShipName = entity.ShipName;
                    header.ShipAddress = entity.ShipAddress;
                    header.ShipCity = entity.ShipCity;
                    header.ShipRegion = entity.ShipRegion;
                    header.ShipPostalCode = entity.ShipPostalCode;
                    header.ShipCountry = entity.ShipCountry;

                    Uow.OrderRepository.Add(header);

                    await Uow.CommitChangesAsync();

                    foreach (var summary in entity.OrderSummaries)
                    {
                        var detail = new OrderDetail();

                        var product = Uow.ProductRepository.Get(new Product(summary.ProductID));

                        if (product == null)
                        {
                            throw new NullEntityException(String.Format("The product with ID : '{0}' is not exists in database.", detail.ProductID));
                        }

                        if (product.Discontinued == true)
                        {
                            throw new DiscontinuedProductException(String.Format("The product with ID : '{0}' is discontinued.", product.ProductID));
                        }

                        detail.OrderID = header.OrderID;
                        detail.ProductID = summary.ProductID;
                        detail.Quantity = summary.Quantity;
                        detail.UnitPrice = product.UnitPrice;
                        detail.Discount = (Single)summary.Discount;

                        Uow.OrderDetailRepository.Add(detail);

                        product.UnitsInStock -= detail.Quantity;
                        product.UnitsOnOrder += detail.Quantity;

                        Uow.ProductRepository.Update(product);
                    }

                    await Uow.CommitChangesAsync();

                    entity.OrderID = header.OrderID;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }

            return header;
        }

        async Task<IEnumerable<Order>> GetOrdersByShipVia(Int32? shipVia)
        {
            return await Task.Run(() =>
            {
                return Uow.OrderRepository.GetAll().Where(item => item.ShipVia == shipVia);
            });
        }
    }
}
