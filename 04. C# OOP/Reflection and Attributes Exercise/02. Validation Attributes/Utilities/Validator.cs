using System.Reflection;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities;

public abstract class Validator
{
    public static bool IsValid(object obj)
    {
        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties()
            .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
            .ToArray();

        foreach (var validationProp in properties)
        {

        }

        return false;
    }
}