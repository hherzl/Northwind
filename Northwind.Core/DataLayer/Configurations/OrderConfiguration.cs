using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class OrderConfiguration : EntityTypeConfiguration<Order>, IEntityConfiguration
    {
        public OrderConfiguration()
        {
            ToTable("Orders");

            HasKey(p => new { p.OrderID });

            Property(p => p.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.OrderID).HasColumnName("OrderID").HasColumnType("int").IsRequired();

            Property(p => p.CustomerID).HasColumnName("CustomerID").HasColumnType("nchar").HasMaxLength(10).IsOptional();

            Property(p => p.EmployeeID).HasColumnName("EmployeeID").HasColumnType("int").IsOptional();

            Property(p => p.OrderDate).HasColumnName("OrderDate").HasColumnType("datetime").IsOptional();

            Property(p => p.RequiredDate).HasColumnName("RequiredDate").HasColumnType("datetime").IsOptional();

            Property(p => p.ShippedDate).HasColumnName("ShippedDate").HasColumnType("datetime").IsOptional();

            Property(p => p.ShipVia).HasColumnName("ShipVia").HasColumnType("int").IsOptional();

            Property(p => p.Freight).HasColumnName("Freight").HasColumnType("money").IsOptional();

            Property(p => p.ShipName).HasColumnName("ShipName").HasColumnType("nvarchar").HasMaxLength(80).IsOptional();

            Property(p => p.ShipAddress).HasColumnName("ShipAddress").HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.ShipCity).HasColumnName("ShipCity").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.ShipRegion).HasColumnName("ShipRegion").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.ShipPostalCode).HasColumnName("ShipPostalCode").HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.ShipCountry).HasColumnName("ShipCountry").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

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
