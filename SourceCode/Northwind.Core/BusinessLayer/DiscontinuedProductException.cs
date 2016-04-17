using System;

namespace Northwind.Core.BusinessLayer
{
    public class DiscontinuedProductException : Exception
    {
        public DiscontinuedProductException()
            : base()
        {
        }

        public DiscontinuedProductException(String message)
            : base(message)
        {
        }
    }
}
