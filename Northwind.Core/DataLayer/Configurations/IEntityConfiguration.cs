using System.Data.Entity.ModelConfiguration.Configuration;

namespace Northwind.Core.DataLayer.Configurations
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
