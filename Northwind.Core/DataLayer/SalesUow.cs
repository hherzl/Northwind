using System;
using System.Data.Entity;
using System.Threading.Tasks;
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
                return m_supplierRepository ?? (m_supplierRepository = new SupplierRepository(DbCtx));
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return m_categoryRepository ?? (m_categoryRepository = new CategoryRepository(DbCtx));
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return m_productRepository ?? (m_productRepository = new ProductRepository(DbCtx));
            }
        }

        public IShipperRepository ShipperRepository
        {
            get
            {
                return m_shipperRepository ?? (m_shipperRepository = new ShipperRepository(DbCtx));
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return m_customerRepository ?? (m_customerRepository = new CustomerRepository(DbCtx));
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return m_employeeRepository ?? (m_employeeRepository = new EmployeeRepository(DbCtx));
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return m_orderRepository ?? (m_orderRepository = new OrderRepository(DbCtx));
            }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                return m_orderDetailRepository ?? (m_orderDetailRepository = new OrderDetailRepository(DbCtx));
            }
        }

        public IRegionRepository RegionRepository
        {
            get
            {
                return m_regionRepository ?? (m_regionRepository = new RegionRepository(DbCtx));
            }
        }

        public ICategorySaleFor1997Repository CategorySaleFor1997Repository
        {
            get
            {
                return m_categorySaleFor1997Repository ?? (m_categorySaleFor1997Repository = new CategorySaleFor1997Repository(DbCtx));
            }
        }

        public void CreateOrder(Order entity)
        {
            using (var transaction = new TransactionScope())
            {
                var header = new Order();

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

                OrderRepository.Add(header);

                CommitChanges();

                foreach (var summary in entity.OrderSummaries)
                {
                    var detail = new OrderDetail();

                    detail.OrderID = header.OrderID;
                    detail.ProductID = summary.ProductID;
                    detail.Quantity = summary.Quantity;
                    detail.UnitPrice = summary.UnitPrice;
                    detail.Discount = (Single)summary.Discount;

                    OrderDetailRepository.Add(detail);

                    var product = ProductRepository.Get(new Product() { ProductID = detail.ProductID });

                    product.UnitsInStock -= detail.Quantity;
                    product.UnitsOnOrder += detail.Quantity;

                    ProductRepository.Update(product);
                }

                CommitChanges();

                entity.OrderID = header.OrderID;

                transaction.Complete();
            }
        }
    }
}
