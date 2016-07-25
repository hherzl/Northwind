using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>, IEntityConfiguration
    {
        public ShoppingCartMap()
        {
            ToTable("ShoppingCart");

            HasKey(p => new { p.ShoppingCartID });

            Property(p => p.ShoppingCartID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ShoppingCartID).HasColumnType("int").IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
