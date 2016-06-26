using System;
using System.Collections.Generic;
using Northwind.Core.DataLayer.DataContracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.BusinessLayer.Contracts
{
    public interface ISalesBusinessObject : IBusinessObject
    {
        IEnumerable<OrderSummary> GetOrderSummaries(String customerID, Int32? employeeID, Int32? shipperID);

        Order GetOrder(Order entity);

        Order CreateOrder(Order entity);

        IEnumerable<ProductDetail> GetProductsDetails(Int32? supplierID, Int32? categoryID, String productName);

        Product GetProduct(Product entity);

        Product CreateProduct(Product entity);

        Product UpdateProduct(Product entity);

        Product DeleteProduct(Product entity);

        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(Employee entity);

        IEnumerable<Category> GetCategories();

        Category GetCategory(Category entity);

        Category CreateCategory(Category entity);

        Category UpdateCategory(Category entity);

        Category DeleteCategory(Category entity);

        IEnumerable<Supplier> GetSuppliers();

        Supplier GetSupplier(Supplier entity);

        Supplier CreateSupplier(Supplier entity);

        Supplier UpdateSupplier(Supplier entity);

        Supplier DeleteSupplier(Supplier entity);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(Customer entity);

        Customer CreateCustomer(Customer entity);

        Customer UpdateCustomer(Customer entity);

        Customer DeleteCustomer(Customer entity);

        IEnumerable<Shipper> GetShippers();

        Shipper GetShipper(Shipper entity);

        Shipper CreateShipper(Shipper entity);

        Shipper UpdateShipper(Shipper entity);

        Shipper DeleteShipper(Shipper entity);

        IEnumerable<Region> GetRegions();

        Region GetRegion(Region entity);

        Region CreateRegion(Region entity);

        Region UpdateRegion(Region entity);

        Region DeleteRegion(Region entity);
    }
}
