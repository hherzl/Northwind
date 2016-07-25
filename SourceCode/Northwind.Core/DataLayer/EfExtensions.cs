using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.Helpers
{
    public static class EfExtensions
    {
        public static String GetTableName(this DbContext dbContext, Type type)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

            var metadata = objectContext.MetadataWorkspace;

            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings.ToList();

            var tableName = mapping
                .Where(item => item.EntitySet.ElementType.Name == type.Name)
                .First()
                .EntityTypeMappings[0]
                .Fragments[0]
                .StoreEntitySet
                .MetadataProperties["Table"]
                .Value;

            return tableName.ToString();
        }

        public static String GetColumnName(this DbContext dbContext, Type type, String propertyName)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

            var metadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace();

            var items = metadata.GetItems(DataSpace.SSpace);

            var entity = items
                .Where(item => item.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .Select(item => item as EntityType)
                .Where(item => item.Name == type.Name)
                .SingleOrDefault();

            for (var i = 0; i < entity.Properties.Count; i++)
            {
                if (entity.Properties[i].MetadataProperties[3].Value.ToString() == propertyName)
                {
                    return entity.Properties[i].Name;
                }
            }

            return String.Empty;
        }

        public static IEnumerable<ChangeLog> GetChanges(this DbContext dbContext, DbEntityEntry entry)
        {
            foreach (var propertyName in entry.OriginalValues.PropertyNames)
            {
                var original = entry.OriginalValues.GetValue<Object>(propertyName);

                var current = entry.CurrentValues.GetValue<Object>(propertyName);

                if (original == null || current == null)
                {
                    continue;
                }

                var type = entry.Entity.GetType();

                var tableName = dbContext.GetTableName(type);

                if (original.ToString() != current.ToString())
                {
                    yield return new ChangeLog()
                    {
                        TableName = tableName,
                        ColumnName = propertyName,
                        Value = current.ToString(),
                        CreationDate = DateTime.Now
                    };
                }
            }
        }

        public static IEnumerable<DbValidationError> GetEntityValidationErrors(this Exception ex)
        {
            var dbEntityValidationException = ex as DbEntityValidationException;

            if (dbEntityValidationException != null)
            {
                foreach (var validationError in dbEntityValidationException.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    yield return validationError;
                }
            }
        }
    }
}
