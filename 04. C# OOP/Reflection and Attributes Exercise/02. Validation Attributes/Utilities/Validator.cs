using System.Reflection;
using ValidationAttributes.Utilities.Attributes;

namespace _02._Validation_Attributes.Utilities;

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
            var customAttributes = validationProp.CustomAttributes.ToArray();

            object propValue = validationProp.GetValue(obj);

            foreach (var customAttribute in customAttributes)
            {
                Type attributeType = customAttribute.AttributeType;
                MethodInfo isValidMethod = attributeType
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .FirstOrDefault(mi => mi.Name == "IsValid");

                if (isValidMethod == null)
                {
                    throw new InvalidOperationException("Invalid method!");
                }

                object attributeInstance = Activator.CreateInstance(attributeType);
                bool result = (bool)isValidMethod
                    .Invoke(attributeInstance, new object[] { propValue});

                if (!result)
                {
                    return false;
                }
            }
        }

        return true;
    }
}