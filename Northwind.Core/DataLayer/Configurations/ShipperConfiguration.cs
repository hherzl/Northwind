using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Configurations
{
    [Export(typeof(IEntityConfiguration))]
    public class ShipperConfiguration : EntityTypeConfiguration<Shipper>, IEntityConfiguration
    {
        public ShipperConfiguration()
        {
            ToTable("Shippers");

            HasKey(p => new { p.ShipperID });

            Property(p => p.ShipperID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ShipperID).HasColumnName("ShipperID").HasColumnType("int").IsRequired();

            Property(p => p.CompanyName).HasColumnName("CompanyName").HasColumnType("nvarchar").HasMaxLength(80).IsRequired();

            Property(p => p.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(48).IsOptional();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
