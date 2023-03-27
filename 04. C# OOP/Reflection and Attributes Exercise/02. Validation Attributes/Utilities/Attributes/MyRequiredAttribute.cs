using ValidationAttributes.Utilities.Attributes;

namespace _02._Validation_Attributes.Utilities.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MyRequiredAttribute : MyValidationAttribute
{
    public override bool IsValid(object value)
        => value != null;
}