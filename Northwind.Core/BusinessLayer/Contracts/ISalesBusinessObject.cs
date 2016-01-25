using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer.Contracts
{
    public interface ISalesBusinessObject : IBusinessObject
    {
        Task<IEnumerable<OrderSummary>> GetOrderSummaries();

        Task<Order> GetOrder(Order entity);

        Task<Order> CreateOrder(Order entity);

        Task<IEnumerable<ProductDetail>> GetProductsDetails(String productName, Int32? supplierID, Int32? categoryID);

        Task<Product> GetProduct(Product entity);

        Task<Product> CreateProduct(Product entity);

        Task<Product> UpdateProduct(Product entity);

        Task<Product> DeleteProduct(Product entity);

        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(Employee entity);

        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplier(Supplier entity);

        Task<Supplier> CreateSupplier(Supplier entity);

        Task<Supplier> UpdateSupplier(Supplier entity);

        Task<Supplier> DeleteSupplier(Supplier entity);

        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> GetCustomer(Customer entity);

        Task<Customer> CreateCustomer(Customer entity);

        Task<Customer> UpdateCustomer(Customer entity);

        Task<Customer> DeleteCustomer(Customer entity);
    }
}
