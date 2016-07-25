using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class ShoppingCartItemMap : EntityTypeConfiguration<ShoppingCartItem>, IEntityConfiguration
    {
        public ShoppingCartItemMap()
        {
            ToTable("ShoppingCartItem");

            HasKey(p => new { p.ShoppingCartItemID });

            Property(p => p.ShoppingCartItemID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ShoppingCartItemID).HasColumnType("int").IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
