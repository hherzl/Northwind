using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderMap : EntityTypeConfiguration<Order>, IEntityConfiguration
    {
        public OrderMap()
        {
            ToTable("Orders");

            HasKey(p => new { p.OrderID });

            Property(p => p.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.OrderID).HasColumnType("int").IsRequired();

            Property(p => p.CustomerID).HasColumnType("nchar").HasMaxLength(10).IsOptional();

            Property(p => p.EmployeeID).HasColumnType("int").IsOptional();

            Property(p => p.OrderDate).HasColumnType("datetime").IsOptional();

            Property(p => p.RequiredDate).HasColumnType("datetime").IsOptional();

            Property(p => p.ShippedDate).HasColumnType("datetime").IsOptional();

            Property(p => p.ShipVia).HasColumnType("int").IsOptional();

            Property(p => p.Freight).HasColumnType("money").IsOptional();

            Property(p => p.ShipName).HasColumnType("nvarchar").HasMaxLength(80).IsOptional();

            Property(p => p.ShipAddress).HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.ShipCity).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.ShipRegion).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.ShipPostalCode).HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.ShipCountry).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            HasOptional(p => p.FkOrdersCustomers).WithMany(p => p.Orders).HasForeignKey(p => p.CustomerID).WillCascadeOnDelete(false);

            HasOptional(p => p.FkOrdersEmployees).WithMany(p => p.Orders).HasForeignKey(p => p.EmployeeID).WillCascadeOnDelete(false);

            HasOptional(p => p.FkOrdersShippers).WithMany(p => p.Orders).HasForeignKey(p => p.ShipVia).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
