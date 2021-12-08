/*
 * ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores
{
    /// <summary>Aids in object validation.</summary>
    public static  class ObjectValidator
    {
        /// <summary>Enumerates a list of errors.</summary>
        /// <param name="instance"></param>
        /// <returns>A list of errors in validation.</returns>
        public static IEnumerable<ValidationResult> TryValidate (IValidatableObject instance )
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(instance);

            Validator.TryValidateObject(instance, context, errors);

            return errors;
        }

        /// <summmary>Determines whether or not the object is valid using context</summmary>
        /// <param name="instance"></param>
        /// <param name="error"></param>
        /// <returns>Validation result</returns>
        public static bool TryValidate ( IValidatableObject instance, out string error )
        {
            var errors = TryValidate(instance);

            error = errors.FirstOrDefault()?.ErrorMessage;

            return String.IsNullOrEmpty(error);
        }

        /// <summary>
        /// Performs validation checks
        /// </summary>
        /// <param name="instance"></param>
        public static void Validate ( IValidatableObject instance )
        {
            var context = new ValidationContext(instance);
            Validator.ValidateObject(instance, context, true);
        }
    }
}