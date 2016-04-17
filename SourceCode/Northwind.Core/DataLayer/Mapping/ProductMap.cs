using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class ProductMap : EntityTypeConfiguration<Product>, IEntityConfiguration
    {
        public ProductMap()
        {
            ToTable("Products");

            HasKey(p => new { p.ProductID });

            Property(p => p.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ProductID).HasColumnType("int").IsRequired();

            Property(p => p.ProductName).HasColumnType("nvarchar").HasMaxLength(80).IsRequired();

            Property(p => p.SupplierID).HasColumnType("int").IsOptional();

            Property(p => p.CategoryID).HasColumnType("int").IsOptional();

            Property(p => p.QuantityPerUnit).HasColumnType("nvarchar").HasMaxLength(40).IsOptional();

            Property(p => p.UnitPrice).HasColumnType("money").IsOptional();

            Property(p => p.UnitsInStock).HasColumnType("smallint").IsOptional();

            Property(p => p.UnitsOnOrder).HasColumnType("smallint").IsOptional();

            Property(p => p.ReorderLevel).HasColumnType("smallint").IsOptional();

            Property(p => p.Discontinued).HasColumnType("bit").IsRequired();

            HasOptional(p => p.FkProductsCategories).WithMany(p => p.Products).HasForeignKey(p => p.CategoryID).WillCascadeOnDelete(false);

            HasOptional(p => p.FkProductsSuppliers).WithMany(p => p.Products).HasForeignKey(p => p.SupplierID).WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
