using System.Data.Entity.ModelConfiguration.Configuration;

namespace Northwind.Core.DataLayer.Mapping
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
