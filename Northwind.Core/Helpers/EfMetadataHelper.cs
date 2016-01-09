using System;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Northwind.Core.Helpers
{
    public static class EfMetadataHelper
    {
        public static String GetTableName(DbContext dbContext, Type type)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

            var metadata = objectContext.MetadataWorkspace;

            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings.ToList();

            var tableName = mapping.Where(item => item.EntitySet.ElementType.Name == type.Name).First().EntityTypeMappings[0].Fragments[0].StoreEntitySet.MetadataProperties["Table"].Value;

            return tableName.ToString();
        }

        public static String GetColumnName(DbContext dbContext, Type type, String propertyName)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

            var metadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace();

            var items = metadata.GetItems(DataSpace.SSpace);

            var entity = items.Where(item => item.BuiltInTypeKind == BuiltInTypeKind.EntityType).Select(item => item as EntityType).Where(item => item.Name == type.Name).SingleOrDefault();

            for (var i = 0; i < entity.Properties.Count; i++)
            {
                if (entity.Properties[i].MetadataProperties[3].Value.ToString() == propertyName)
                {
                    return entity.Properties[i].Name;
                }
            }

            return String.Empty;
        }
    }
}
