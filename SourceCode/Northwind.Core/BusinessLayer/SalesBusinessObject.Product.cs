using System;
using System.Collections.Generic;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public IEnumerable<ProductDetail> GetProductsDetails(Int32? supplierID, Int32? categoryID, String productName)
        {
            return Uow.ProductRepository.GetDetails(supplierID, categoryID, productName);
        }

        public Product GetProduct(Product entity)
        {
            return Uow.ProductRepository.Get(entity);
        }

        public Product CreateProduct(Product entity)
        {
            Uow.ProductRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Product UpdateProduct(Product value)
        {
            var entity = Uow.ProductRepository.Get(value);

            if (entity != null)
            {
                entity.ProductName = value.ProductName;
                entity.SupplierID = value.SupplierID;
                entity.CategoryID = value.CategoryID;
                entity.QuantityPerUnit = value.QuantityPerUnit;
                entity.UnitPrice = value.UnitPrice;

                Uow.ProductRepository.Update(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public Product DeleteProduct(Product value)
        {
            var entity = Uow.ProductRepository.Get(value);

            if (entity != null)
            {
                Uow.ProductRepository.Remove(entity);

                Uow.CommitChanges();
            }

            return entity;
        }
    }
}
