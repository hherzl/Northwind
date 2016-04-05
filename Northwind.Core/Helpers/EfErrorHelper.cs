using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Helpers
{
    public static class EfErrorHelper
    {
        public static IEnumerable<DbValidationError> GetEntityValidationErrors(Exception ex)
        {
            var entityValidationException = ex as DbEntityValidationException;

            if (entityValidationException != null)
            {
                foreach (var validationError in entityValidationException.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    yield return validationError;
                }
            }
        }

        public static IEnumerable<DbValidationError> ExtractValidationMessages(this Exception ex)
        {
            var result = new List<DbValidationError>();

            var dbEntityValidationException = ex as DbEntityValidationException;

            if (dbEntityValidationException != null)
            {
                foreach (var validationError in dbEntityValidationException.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    result.Add(validationError);
                }
            }

            return result;
        }
    }
}
