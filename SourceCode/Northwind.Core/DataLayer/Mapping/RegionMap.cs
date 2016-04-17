using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class RegionMap : EntityTypeConfiguration<Region>, IEntityConfiguration
    {
        public RegionMap()
        {
            ToTable("Region");

            HasKey(p => new { p.RegionID });

            Property(p => p.RegionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.RegionID).HasColumnType("int").IsRequired();

            Property(p => p.RegionDescription).HasColumnType("nchar").HasMaxLength(100).IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
