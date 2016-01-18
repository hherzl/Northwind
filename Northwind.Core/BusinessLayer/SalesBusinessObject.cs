using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public class SalesBusinessObject : ISalesBusinessObject
    {
        protected ISalesUow Uow;

        public SalesBusinessObject(ISalesUow uow)
        {
            Uow = uow;
        }

        public void Release()
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }
        }

        public async Task<IEnumerable<OrderSummary>> GetOrderSummaries()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .OrderRepository
                    .GetSummaries()
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
                    header.OrderDate = DateTime.Now;
                    header.ShipVia = entity.ShipVia;
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

                        var product = Uow.ProductRepository.Get(new Product(detail.ProductID));

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
                catch
                {
                    transaction.Rollback();
                }
            }

            return header;
        }
    }
}
