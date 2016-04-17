using System;

namespace Northwind.Core.BusinessLayer
{
    public class ForeignKeyDependencyException : Exception
    {
        public ForeignKeyDependencyException()
            : base()
        {
        }

        public ForeignKeyDependencyException(String message)
            : base(message)
        {
        }
    }
}
