namespace Northwind.Core.DataLayer.OperationContracts
{
    public interface ISalesUow : IUow
    {
        ISupplierRepository SupplierRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IProductRepository ProductRepository { get; }

        IShipperRepository ShipperRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderDetailRepository OrderDetailRepository { get; }

        IRegionRepository RegionRepository { get; }

        ICategorySaleFor1997Repository CategorySaleFor1997Repository { get; }
    }
}
