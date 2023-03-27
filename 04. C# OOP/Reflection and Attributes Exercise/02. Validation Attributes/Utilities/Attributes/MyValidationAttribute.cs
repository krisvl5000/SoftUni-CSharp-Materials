namespace ValidationAttributes.Utilities.Attributes;

public abstract class MyValidationAttribute : Attribute
{
    public abstract bool IsValid(object value);
}