using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityConfiguration))]
    public class ChangeLogMap : EntityTypeConfiguration<ChangeLog>, IEntityConfiguration
    {
        public ChangeLogMap()
        {
            ToTable("ChangeLog");

            HasKey(p => new { p.ChangeLogID });

            Property(p => p.ChangeLogID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ChangeLogID).HasColumnType("int").IsRequired();

            Property(p => p.TableName).HasColumnType("varchar").HasMaxLength(255).IsRequired();

            Property(p => p.ColumnName).HasColumnType("varchar").HasMaxLength(255).IsRequired();
            
            Property(p => p.Value).HasColumnType("varchar").HasMaxLength(255).IsRequired();

            Property(p => p.CreationDate).HasColumnType("datetime").IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
