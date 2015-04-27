using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>, IEntityConfiguration
    {
        public OrderDetailConfiguration()
        {
            ToTable("Order Details");

            HasKey(p => new { p.OrderID, p.ProductID });

            Property(p => p.OrderID).HasColumnName("OrderID").HasColumnType("int").IsRequired();

            Property(p => p.ProductID).HasColumnName("ProductID").HasColumnType("int").IsRequired();

            Property(p => p.UnitPrice).HasColumnName("UnitPrice").HasColumnType("money").IsRequired();

            Property(p => p.Quantity).HasColumnName("Quantity").HasColumnType("smallint").IsRequired();

            Property(p => p.Discount).HasColumnName("Discount").HasColumnType("real").IsRequired();

            HasRequired(p => p.FkOrderDetailsOrders).WithMany(p => p.OrderDetails).HasForeignKey(p => p.OrderID).WillCascadeOnDelete(false);

            //HasRequired(p => p.FkOrderDetailsProducts).WithMany(p => p.OrderDetails).HasForeignKey(p => p.ProductID).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
