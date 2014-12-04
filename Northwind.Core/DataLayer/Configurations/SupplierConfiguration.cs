using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>, IEntityConfiguration
    {
        public SupplierConfiguration()
        {
            ToTable("Suppliers");

            HasKey(p => new { p.SupplierID });

            Property(p => p.SupplierID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.SupplierID).HasColumnName("SupplierID").HasColumnType("int").IsRequired();

            Property(p => p.CompanyName).HasColumnName("CompanyName").HasColumnType("nvarchar").HasMaxLength(80).IsRequired();

            Property(p => p.ContactName).HasColumnName("ContactName").HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.ContactTitle).HasColumnName("ContactTitle").HasColumnType("nvarchar").HasMaxLength(60).IsOptional();

            Property(p => p.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(120).IsOptional();

            Property(p => p.City).HasColumnName("City").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Region).HasColumnName("Region").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.PostalCode).HasColumnName("PostalCode").HasColumnType("nvarchar").HasMaxLength(20).IsOptional();

            Property(p => p.Country).HasColumnName("Country").HasColumnType("nvarchar").HasMaxLength(30).IsOptional();

            Property(p => p.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.Fax).HasColumnName("Fax").HasColumnType("nvarchar").HasMaxLength(48).IsOptional();

            Property(p => p.HomePage).HasColumnName("HomePage").HasColumnType("ntext").IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
