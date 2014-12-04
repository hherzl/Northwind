using Northwind.Core.DataLayer.Contracts;

namespace Northwind.Core.BusinessLayer
{
    public interface ISalesUow : IUow
    {
        void CommitChanges();

        ISupplierRepository SupplierRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IProductRepository ProductRepository { get; }

        IShipperRepository ShipperRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderDetailRepository OrderDetailRepository { get; }
    }
}
