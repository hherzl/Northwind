using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class CategorySaleFor1997Configuration : EntityTypeConfiguration<CategorySaleFor1997>, IEntityConfiguration
    {
        public CategorySaleFor1997Configuration()
        {
            ToTable("Category Sales for 1997");

            HasKey(p => new { p.CategoryName });

            Property(p => p.CategoryName).HasColumnName("CategoryName").HasColumnType("nvarchar").IsRequired();

            Property(p => p.CategorySales).HasColumnName("CategorySales").HasColumnType("decimal").IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
