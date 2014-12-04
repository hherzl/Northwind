using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Northwind.Core.Extensions
{
    public static class CollectionExtensor
    {
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            Collection<T> collection = new Collection<T>();

            foreach(T item in source)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
