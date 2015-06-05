using System;
using System.Data.Entity;
using Northwind.Core.DataLayer.OperationContracts;
using Northwind.Core.DataLayer;

namespace Northwind.Core.DataLayer
{
    public class SalesUow : ISalesUow
    {
        protected Boolean m_disposed;
        private DbContext m_dbContext;
        private ISupplierRepository m_supplierRepository;
        private ICategoryRepository m_categoryRepository;
        private IProductRepository m_productRepository;
        private IShipperRepository m_shipperRepository;
        private ICustomerRepository m_customerRepository;
        private IEmployeeRepository m_employeeRepository;
        private IOrderRepository m_orderRepository;
        private IOrderDetailRepository m_orderDetailRepository;
        private IRegionRepository m_regionRepository;
        private ICategorySaleFor1997Repository m_categorySaleFor1997Repository;

        public SalesUow(DbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_dbContext.Dispose();
                }
            }

            m_disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public Int32 CommitChanges()
        {
            if (m_dbContext.ChangeTracker.HasChanges())
            {
                return m_dbContext.SaveChanges();
            }

            return 0;
        }

        public ISupplierRepository SupplierRepository
        {
            get
            {
                return m_supplierRepository ?? (m_supplierRepository = new SupplierRepository(m_dbContext));
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return m_categoryRepository ?? (m_categoryRepository = new CategoryRepository(m_dbContext));
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return m_productRepository ?? (m_productRepository = new ProductRepository(m_dbContext));
            }
        }

        public IShipperRepository ShipperRepository
        {
            get
            {
                return m_shipperRepository ?? (m_shipperRepository = new ShipperRepository(m_dbContext));
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return m_customerRepository ?? (m_customerRepository = new CustomerRepository(m_dbContext));
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return m_employeeRepository ?? (m_employeeRepository = new EmployeeRepository(m_dbContext));
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return m_orderRepository ?? (m_orderRepository = new OrderRepository(m_dbContext));
            }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                return m_orderDetailRepository ?? (m_orderDetailRepository = new OrderDetailRepository(m_dbContext));
            }
        }

        public IRegionRepository RegionRepository
        {
            get
            {
                return m_regionRepository ?? (m_regionRepository = new RegionRepository(m_dbContext));
            }
        }

        public ICategorySaleFor1997Repository CategorySaleFor1997Repository
        {
            get
            {
                return m_categorySaleFor1997Repository ?? (m_categorySaleFor1997Repository = new CategorySaleFor1997Repository(m_dbContext));
            }
        }
    }
}
