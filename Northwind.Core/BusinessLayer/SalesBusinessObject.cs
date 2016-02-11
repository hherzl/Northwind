using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.DataLayer.Contracts;

namespace Northwind.Core.BusinessLayer
{
    public partial class SalesBusinessObject : ISalesBusinessObject
    {
        protected ISalesUow Uow;

        public SalesBusinessObject(ISalesUow uow)
        {
            Uow = uow;
        }

        public void Release()
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }
        }
    }
}
