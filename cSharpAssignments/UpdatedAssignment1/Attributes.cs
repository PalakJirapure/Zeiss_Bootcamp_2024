using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceValidatorAssignment
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && !string.IsNullOrWhiteSpace(value.ToString());
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : ValidationAttribute
    {
        public int Minimum { get; }
        public int Maximum { get; }

        public RangeAttribute(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                return intValue >= Minimum && intValue <= Maximum;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : ValidationAttribute
    {
        public int MaxLength { get; }

        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value is string strValue)
            {
                return strValue.Length <= MaxLength;
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomValidationAttribute : ValidationAttribute
    {
        private readonly string _customValidationParameter;

        public CustomValidationAttribute(string customValidationParameter)
        {
            _customValidationParameter = customValidationParameter;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; // Validation is successful for null values.
            }

            string stringValue = value.ToString();

            // Custom validation logic based on the provided parameter.
            return stringValue.Contains(_customValidationParameter);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PatternAttribute : ValidationAttribute
    {
        private readonly string _pattern;

        public PatternAttribute(string pattern)
        {
            _pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; // Validation is successful for null values.
            }

            string stringValue = value.ToString();

            // Regular expression validation
            return System.Text.RegularExpressions.Regex.IsMatch(stringValue, _pattern);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class BarcodePatternAttribute : PatternAttribute
    {
        public BarcodePatternAttribute() : base("^Z\\d{12}$")
        {
        }
    }
}
