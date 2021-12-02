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
        /// <summary>
        /// Determines if an enumerable object is valid.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>A list of errors in validation.</returns>
        public static IEnumerable<ValidationResult> TryValidate (IValidatableObject instance )
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(instance);

            Validator.TryValidateObject(instance, context, errors);

            return errors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool TryValidate ( IValidatableObject instance, out string error )
        {
            var errors = TryValidate(instance);

            error = errors.FirstOrDefault()?.ErrorMessage;

            return String.IsNullOrEmpty(error);
        }

        public static void Validate ( IValidatableObject instance )
        {
            var context = new ValidationContext(instance);
            Validator.ValidateObject(instance, context, true);
        }
    }
}