using System;
using System.Transactions;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public static class OrderExtension
    {
        public static void CreateOrder(this ISalesUow uow, Order header, OrderDetail[] details)
        {
            using (var transaction = new TransactionScope())
            {
                uow.OrderRepository.Add(header);

                foreach (var detail in details)
                {
                    detail.OrderID = header.OrderID;

                    uow.OrderDetailRepository.Add(detail);

                    var product = uow.ProductRepository.Get(new Product() { ProductID = detail.ProductID });

                    product.UnitsInStock -= detail.Quantity;
                    product.UnitsOnOrder += detail.Quantity;

                    uow.ProductRepository.Update(product);
                }

                uow.CommitChanges();

                transaction.Complete();
            }
        }
    }
}
