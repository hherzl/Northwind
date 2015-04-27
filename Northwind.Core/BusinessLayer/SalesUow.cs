using System;
using System.Data.Entity;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.DataLayer.Operations;
using Northwind.Core.DataLayer.Repositories;

namespace Northwind.Core.BusinessLayer
{
    public class SalesUow : ISalesUow
    {
        private DbContext m_dbContext;
        private ISupplierRepository m_supplierRepository;
        private ICategoryRepository m_categoryRepository;
        private IProductRepository m_productRepository;
        private IShipperRepository m_shipperRepository;
        private ICustomerRepository m_customerRepository;
        private IEmployeeRepository m_employeeRepository;
        private IOrderRepository m_orderRepository;
        private IOrderDetailRepository m_orderDetailRepository;
        protected Boolean Disposed;

        public SalesUow(DbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void CommitChanges()
        {
            if (m_dbContext.ChangeTracker.HasChanges())
            {
                m_dbContext.SaveChanges();
            }
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

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    m_dbContext.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
