using System.Reflection;

namespace TestHelpers;

public static class TestPropertySetter
{
    public static void SetPrivateProperty(object obj, string propertyName, object value)
    {
        var propertyInfo = obj.GetType().GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
        propertyInfo?.SetValue(obj, value);
    }
}