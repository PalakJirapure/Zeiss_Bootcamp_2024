using System;
using System.Collections.Generic;
using System.Reflection;

public static class ObjectValidator
{
    public static bool Validate<T>(T obj, out List<string> errors)
    {
        errors = new List<string>();

        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute(typeof(RequiredAttribute)) != null)
            {
                var value = property.GetValue(obj);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errors.Add($"{property.Name} is required.");
                }
            }

            if (property.GetCustomAttribute(typeof(RangeAttribute)) != null)
            {
                var rangeAttribute = (RangeAttribute)property.GetCustomAttribute(typeof(RangeAttribute));
                var value = (int)property.GetValue(obj);
                if (value < rangeAttribute.Minimum || value > rangeAttribute.Maximum)
                {
                    errors.Add($"{property.Name} must be within the range {rangeAttribute.Minimum}-{rangeAttribute.Maximum}.");
                }
            }

            if (property.GetCustomAttribute(typeof(MaxLengthAttribute)) != null)
            {
                var maxLengthAttribute = (MaxLengthAttribute)property.GetCustomAttribute(typeof(MaxLengthAttribute));
                var value = property.GetValue(obj) as string;
                if (value != null && value.Length > maxLengthAttribute.MaxLength)
                {
                    errors.Add($"{property.Name} must have a maximum length of {maxLengthAttribute.MaxLength} characters.");
                }
            }
        }

        return errors.Count == 0;
    }
}
