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

            foreach (PropertyInfo property in properties)
            {
                object[] validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (object attribute in validationAttributes)
                {
                    if (attribute is ValidationAttribute)
                    {
                        ValidationAttribute validationAttribute = (ValidationAttribute)attribute;

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
