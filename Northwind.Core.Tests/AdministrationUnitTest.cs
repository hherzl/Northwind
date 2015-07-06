using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;

namespace Northwind.Core.Tests
{
    [TestClass]
    public class AdministrationUnitTest
    {
        [TestMethod]
        public void SearchProductsLinqQuery()
        {
            var dbContext = new SalesDbContext();

            dbContext.Database.Log = s => Console.WriteLine(s);

            var uow = new SalesUow(dbContext) as ISalesUow;

            String productName = null;
            Int32? supplierID = null;
            Int32? categoryID = null;

            //productName = "a";
            //supplierID = 1;
            categoryID = 4;

            var query = uow.ProductRepository.GetDetails(productName, supplierID, categoryID);

            foreach (var item in query.ToList())
            {
                Console.Write("ID: {0},", item.ProductID);
                Console.Write("Name: {0},", item.ProductName);
                Console.Write("Supplier: {0},", item.SupplierID);
                Console.Write("Category: {0}", item.CategoryID);
                Console.WriteLine();
            }
        }
    }
}
