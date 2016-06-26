using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Core.BusinessLayer;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer;
using Northwind.Core.DataLayer.Contracts;

namespace Northwind.Core.Tests
{
    [TestClass]
    public class AdministrationUnitTest
    {
        [TestMethod]
        public async Task SearchProducts()
        {
            var dbContext = new SalesDbContext();

            dbContext.Database.Log = s => Console.WriteLine(s);

            var uow = new SalesUow(dbContext) as ISalesUow;

            var businessObject = new SalesBusinessObject(uow) as ISalesBusinessObject;
            
            Int32? supplierID = null;
            Int32? categoryID = null;
            String productName = null;

            var query = await Task.Run(() =>
                {
                    return businessObject.GetProductsDetails(supplierID, categoryID, productName);
                });

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
