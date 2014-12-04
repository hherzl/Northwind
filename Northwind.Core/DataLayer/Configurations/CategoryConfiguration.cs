using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class CategoryConfiguration : EntityTypeConfiguration<Category>, IEntityConfiguration
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(p => new { p.CategoryID });

            Property(p => p.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.CategoryID).HasColumnName("CategoryID").HasColumnType("int").IsRequired();

            Property(p => p.CategoryName).HasColumnName("CategoryName").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();

            Property(p => p.Description).HasColumnName("Description").HasColumnType("ntext").IsOptional();

            Property(p => p.Picture).HasColumnName("Picture").HasColumnType("image").IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
