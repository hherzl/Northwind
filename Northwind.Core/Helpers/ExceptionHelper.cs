using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Northwind.Core.Helpers
{
    public static class ExceptionHelper
    {
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
