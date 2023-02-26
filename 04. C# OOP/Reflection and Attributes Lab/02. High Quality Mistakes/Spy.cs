using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] fields = classType
                .GetFields(BindingFlags.Public | 
                           BindingFlags.Instance | 
                           BindingFlags.Static | 
                           BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType);

            foreach (FieldInfo field in fields)
            {
                if (requestedFields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance |
                           BindingFlags.Static |
                           BindingFlags.Public);

            MethodInfo[] classPublicMethods = classType
                .GetMethods(BindingFlags.Instance |
                            BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = classType
                .GetMethods(BindingFlags.Instance |
                            BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();


        }
    }
}