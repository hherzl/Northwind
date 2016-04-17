using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        public async Task<IEnumerable<ProductDetail>> GetProductsDetails(String productName, Int32? supplierID, Int32? categoryID)
        {
            return await Task.Run(() =>
            {
                return Uow.ProductRepository.GetDetails(productName, supplierID, categoryID);
            });
        }

        public async Task<Product> GetProduct(Product entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .ProductRepository
                    .Get(new Product(entity.ProductID));
            });
        }

        public async Task<Product> CreateProduct(Product entity)
        {
            Uow.ProductRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateProduct(Product value)
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

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Product> DeleteProduct(Product value)
        {
            var entity = Uow.ProductRepository.Get(value);

            if (entity != null)
            {
                Uow.ProductRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
