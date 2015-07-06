using System.Data.Entity;
using System.Transactions;
using Northwind.Core.DataLayer.Contracts;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer
{
    public class SalesUow : Uow, ISalesUow
    {
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
            : base(dbContext)
        {
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

        public void CreateOrder(Order entity)
        {
            using (var transaction = new TransactionScope())
            {
                OrderRepository.Add(entity);

                foreach (var detail in entity.OrderDetails)
                {
                    detail.OrderID = entity.OrderID;

                    OrderDetailRepository.Add(detail);

                    var product = ProductRepository.Get(new Product() { ProductID = detail.ProductID });

                    product.UnitsInStock -= detail.Quantity;
                    product.UnitsOnOrder += detail.Quantity;

                    ProductRepository.Update(product);
                }

                CommitChanges();

                transaction.Complete();
            }
        }
    }
}
