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
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }

            return header;
        }

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

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .EmployeeRepository
                    .GetAll();
            });
        }

        public async Task<Employee> GetEmployee(Employee entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .EmployeeRepository
                    .Get(entity);
            });
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .SupplierRepository
                    .GetAll();
            });
        }

        public async Task<Supplier> GetSupplier(Supplier entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .SupplierRepository
                    .Get(entity);
            });
        }

        public async Task<Supplier> CreateSupplier(Supplier entity)
        {
            Uow.SupplierRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Supplier> UpdateSupplier(Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.ContactName = value.ContactName;
                entity.ContactTitle = value.ContactTitle;
                entity.Address = value.Address;
                entity.City = value.City;
                entity.Region = value.Region;
                entity.PostalCode = value.PostalCode;
                entity.Country = value.Country;
                entity.Phone = value.Phone;
                entity.Fax = value.Fax;
                entity.HomePage = value.HomePage;

                Uow.SupplierRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Supplier> DeleteSupplier(Supplier value)
        {
            var entity = Uow.SupplierRepository.Get(value);

            if (entity != null)
            {
                Uow.SupplierRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CategoryRepository
                    .GetAll();
            });
        }

        public async Task<Category> GetCategory(Category entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CategoryRepository
                    .Get(entity);
            });
        }

        public async Task<Category> CreateCategory(Category entity)
        {
            Uow.CategoryRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Category> UpdateCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                entity.CategoryName = value.CategoryName;
                entity.Description = value.Description;
                entity.Picture = value.Picture;

                Uow.CategoryRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Category> DeleteCategory(Category value)
        {
            var entity = Uow.CategoryRepository.Get(value);

            if (entity != null)
            {
                Uow.CategoryRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CustomerRepository
                    .GetAll();
            });
        }

        public async Task<Customer> GetCustomer(Customer entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .CustomerRepository
                    .Get(entity);
            });
        }

        public async Task<Customer> CreateCustomer(Customer entity)
        {
            Uow.CustomerRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Customer> UpdateCustomer(Customer value)
        {
            var entity = Uow.CustomerRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.ContactName = value.ContactName;
                entity.ContactTitle = value.ContactTitle;
                entity.Address = value.Address;
                entity.City = value.City;
                entity.Region = value.Region;
                entity.PostalCode = value.PostalCode;
                entity.Country = value.Country;
                entity.Phone = value.Phone;
                entity.Fax = value.Fax;

                Uow.CustomerRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Customer> DeleteCustomer(Customer value)
        {
            var entity = Uow.CustomerRepository.Get(value);

            if (entity != null)
            {
                Uow.CustomerRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .ShipperRepository
                    .GetAll();
            });
        }

        public async Task<Shipper> GetShipper(Shipper entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .ShipperRepository
                    .Get(entity);
            });
        }

        public async Task<Shipper> CreateShipper(Shipper entity)
        {
            Uow.ShipperRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Shipper> UpdateShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                entity.CompanyName = value.CompanyName;
                entity.Phone = value.Phone;

                Uow.ShipperRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Shipper> DeleteShipper(Shipper value)
        {
            var entity = Uow.ShipperRepository.Get(value);

            if (entity != null)
            {
                Uow.ShipperRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await Task.Run(() =>
            {
                return Uow
                    .RegionRepository
                    .GetAll();
            });
        }

        public async Task<Region> GetRegion(Region entity)
        {
            return await Task.Run(() =>
            {
                return Uow
                    .RegionRepository
                    .Get(entity);
            });
        }

        public async Task<Region> CreateRegion(Region entity)
        {
            Uow.RegionRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Region> UpdateRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                entity.RegionDescription = value.RegionDescription;

                Uow.RegionRepository.Update(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }

        public async Task<Region> DeleteRegion(Region value)
        {
            var entity = Uow.RegionRepository.Get(value);

            if (entity != null)
            {
                Uow.RegionRepository.Remove(entity);

                await Uow.CommitChangesAsync();
            }

            return entity;
        }
    }
}
