using System;

namespace Northwind.Core.BusinessLayer
{
    public class NullEntityException : Exception
    {
        public NullEntityException()
            : base()
        {
        }

        public NullEntityException(String message)
            : base(message)
        {
        }
    }
}
