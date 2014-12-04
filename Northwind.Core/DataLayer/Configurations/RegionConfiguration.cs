using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.PocoLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class RegionConfiguration : EntityTypeConfiguration<Region>, IEntityConfiguration
    {
        public RegionConfiguration()
        {
            ToTable("Region");

            HasKey(p => new { p.RegionID });

            Property(p => p.RegionID).HasColumnName("RegionID").HasColumnType("int").IsRequired();

            Property(p => p.RegionDescription).HasColumnName("RegionDescription").HasColumnType("nchar").HasMaxLength(100).IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
