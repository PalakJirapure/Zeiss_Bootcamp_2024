using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DeviceValidatorAssignment
{
    public static class ObjectValidator
    {
        public static bool Validate<T>(T obj, out List<string> errors)
        {
            errors = new List<string>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (var attribute in validationAttributes)
                {
                    if (attribute is ValidationAttribute validationAttribute)
                    {
                        var validationResult = validationAttribute.GetValidationResult(property.GetValue(obj), new ValidationContext(obj));

                        if (validationResult != ValidationResult.Success)
                        {
                            errors.Add(validationResult.ErrorMessage);
                        }
                    }
                }
            }

            return errors.Count == 0;
        }
    }
}
