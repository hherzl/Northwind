using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class ProductConfiguration : EntityTypeConfiguration<Product>, IEntityConfiguration
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            HasKey(p => new { p.ProductID });

            Property(p => p.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ProductID).HasColumnName("ProductID").HasColumnType("int").IsRequired();

            Property(p => p.ProductName).HasColumnName("ProductName").HasColumnType("nvarchar").HasMaxLength(80).IsRequired();

            Property(p => p.SupplierID).HasColumnName("SupplierID").HasColumnType("int").IsOptional();

            Property(p => p.CategoryID).HasColumnName("CategoryID").HasColumnType("int").IsOptional();

            Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit").HasColumnType("nvarchar").HasMaxLength(40).IsOptional();

            Property(p => p.UnitPrice).HasColumnName("UnitPrice").HasColumnType("money").IsOptional();

            Property(p => p.UnitsInStock).HasColumnName("UnitsInStock").HasColumnType("smallint").IsOptional();

            Property(p => p.UnitsOnOrder).HasColumnName("UnitsOnOrder").HasColumnType("smallint").IsOptional();

            Property(p => p.ReorderLevel).HasColumnName("ReorderLevel").HasColumnType("smallint").IsOptional();

            Property(p => p.Discontinued).HasColumnName("Discontinued").HasColumnType("bit").IsRequired();

            HasOptional(p => p.FkProductsCategories).WithMany(p => p.Products).HasForeignKey(p => p.CategoryID).WillCascadeOnDelete(false);

            HasOptional(p => p.FkProductsSuppliers).WithMany(p => p.Products).HasForeignKey(p => p.SupplierID).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
