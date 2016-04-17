using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderDetailSummaryMap : EntityTypeConfiguration<OrderDetailSummary>, IEntityConfiguration
    {
        public OrderDetailSummaryMap()
        {
            ToTable("OrderDetailSummary");

            HasKey(p => new { p.OrderID, p.ProductID });

            Property(p => p.OrderID).HasColumnType("int").IsRequired();

            Property(p => p.ProductID).HasColumnType("int").IsRequired();

            Property(p => p.ProductName).HasColumnType("varchar").IsOptional();

            Property(p => p.UnitPrice).HasColumnType("decimal").IsOptional();

            Property(p => p.Quantity).HasColumnType("int").IsOptional();

            Property(p => p.Discount).HasColumnType("decimal").IsOptional();

            Property(p => p.Total).HasColumnType("decimal").IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
