﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Northwind.Core.EntityLayer;

namespace Northwind.Core.Helpers
{
    public class ChangeTrackerHelper
    {
        public ChangeTrackerHelper(DbContext dbContext)
        {
            Context = dbContext;
        }

        public DbContext Context { get; set; }

        public IEnumerable<ChangeLog> GetChanges(DbEntityEntry entry)
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

                var tableName = EfMetadataHelper.GetTableName(Context, type);

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
    }
}
