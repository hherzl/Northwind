using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class CategoryMap : EntityTypeConfiguration<Category>, IEntityConfiguration
    {
        public CategoryMap()
        {
            ToTable("Categories");

            HasKey(p => new { p.CategoryID });

            Property(p => p.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.CategoryID).HasColumnType("int").IsRequired();

            Property(p => p.CategoryName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();

            Property(p => p.Description).HasColumnType("ntext").IsOptional();

            Property(p => p.Picture).HasColumnType("image").IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
