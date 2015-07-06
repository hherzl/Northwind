using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Northwind.Core.DataLayer.Mapping
{
    public class DbContextConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public IEnumerable<IEntityConfiguration> Configurations { get; set; }
    }
}
