using System;

[AttributeUsage(AttributeTargets.Property)]
public class RequiredAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public class RangeAttribute : Attribute
{
    public int Minimum { get; }
    public int Maximum { get; }

    public RangeAttribute(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
    public int MaxLength { get; }

    public MaxLengthAttribute(int maxLength)
    {
        MaxLength = maxLength;
    }
}
