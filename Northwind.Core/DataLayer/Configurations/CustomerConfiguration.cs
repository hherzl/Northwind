using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>, IEntityConfiguration
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");

            HasKey(p => new { p.CustomerID });

            Property(p => p.CustomerID).HasColumnName("CustomerID").HasColumnType("nchar").HasMaxLength(10).IsRequired();

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
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
