using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Reflection;
using Northwind.Core.DataLayer.Mapping;

namespace Northwind.Core.DataLayer
{
    public class SalesDbContext : System.Data.Entity.DbContext
    {
        public SalesDbContext()
            : base("SalesConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public SalesDbContext(String nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SalesDbContext>(null);

            var contextConfiguration = new DbContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);

            container.ComposeParts(contextConfiguration);

            foreach (var configuration in contextConfiguration.Configurations)
            {
                configuration.AddConfiguration(modelBuilder.Configurations);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
