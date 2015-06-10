using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>, IEntityConfiguration
    {
        public OrderDetailMap()
        {
            ToTable("Order Details");

            HasKey(p => new { p.OrderID, p.ProductID });

            Property(p => p.OrderID).HasColumnType("int").IsRequired();

            Property(p => p.ProductID).HasColumnType("int").IsRequired();

            Property(p => p.UnitPrice).HasColumnType("money").IsRequired();

            Property(p => p.Quantity).HasColumnType("smallint").IsRequired();

            Property(p => p.Discount).HasColumnType("real").IsRequired();

            HasRequired(p => p.FkOrderDetailsOrders).WithMany(p => p.OrderDetails).HasForeignKey(p => p.OrderID).WillCascadeOnDelete(false);

            //HasRequired(p => p.FkOrderDetailsProducts).WithMany(p => p.OrderDetails).HasForeignKey(p => p.ProductID).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
