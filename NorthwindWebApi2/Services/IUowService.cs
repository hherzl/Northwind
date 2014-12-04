using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Core.BusinessLayer;
using Northwind.Core.DataLayer;

namespace NorthwindWebApi2.Services
{
    public interface IUowService
    {
        ISalesUow GetSalesUow();
    }

    public class UowService : IUowService
    {
        public ISalesUow GetSalesUow()
        {
            var dbContext = new SalesDbContext();

            ISalesUow uow = new SalesUow(dbContext);

            return uow;
        }
    }
}
