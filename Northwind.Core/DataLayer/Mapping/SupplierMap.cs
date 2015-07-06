using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class SupplierMap : EntityTypeConfiguration<Supplier>, IEntityConfiguration
    {
        public SupplierMap()
        {
            ToTable("Suppliers");

            HasKey(p => new { p.SupplierID });

            Property(p => p.SupplierID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.SupplierID).HasColumnType("int").IsRequired();

            Property(p => p.CompanyName).HasColumnType("nvarchar").HasMaxLength(80).IsRequired();

            Property(p => p.ContactName).HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.ContactTitle).HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.City).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Region).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.PostalCode).HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.Country).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Phone).HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.Fax).HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.HomePage).HasColumnType("ntext").IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
