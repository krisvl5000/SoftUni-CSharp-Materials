﻿using ValidationAttributes.Utilities.Attributes;

namespace _02._Validation_Attributes.Utilities.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MyRangeAttribute : MyValidationAttribute
{
    private int minValue;
    private int maxValue;

    public MyRangeAttribute(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public override bool IsValid(object value)
    {
        int numValue = (int)value;
        return numValue >= minValue && numValue <= maxValue;
    }
}