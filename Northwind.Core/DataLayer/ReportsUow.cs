using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.Repositories;

namespace Northwind.Core.DataLayer
{
    public class ReportsUow : Uow, IReportsUow
    {
        private ICategorySaleFor1997Repository m_categorySaleFor1997Repository;

        public ReportsUow(DbContext dbContext)
            : base(dbContext)
        {
        }

        public ICategorySaleFor1997Repository CategorySaleFor1997Repository
        {
            get
            {
                return m_categorySaleFor1997Repository ?? (m_categorySaleFor1997Repository = new CategorySaleFor1997Repository(DbContext));
            }
        }
    }
}
