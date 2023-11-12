using System.Reflection;

namespace TestHelpers;

public static class TestSetter
{
    public static void SetPrivateField(object obj, string fieldName, object value)
    {
        var fieldInfo = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo != null)
    {
        fieldInfo.SetValue(obj, value);
    }
    else
    {
        throw new ArgumentException($"Property {fieldInfo} not found or not writable on type {obj.GetType().Name}");
    }
    }

    public static void SetPrivateProperty(object obj, string propertyName, object value)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(obj, value);
        }
        else
        {
            throw new ArgumentException($"Property {propertyName} not found or not writable on type {obj.GetType().Name}");
        }
    }
}