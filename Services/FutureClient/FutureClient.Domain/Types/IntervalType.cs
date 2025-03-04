using System.Reflection;

namespace FutureClient.Domain.Types;

public class IntervalType : BaseType
{
    private IntervalType(string value) : base(value)
    {
    }

    public static readonly IntervalType OneMin = new("1m");
    public static readonly IntervalType FiveMin = new("5m");
    public static readonly IntervalType FifteenMin = new("15m");
    public static readonly IntervalType ThirtyMin = new("30m");

    public static IntervalType? GetPropertyValue(string value)
    {
        var myClassType = typeof(IntervalType);

        FieldInfo[] staticFields = myClassType.GetFields(BindingFlags.Static | BindingFlags.Public);
        
        foreach (FieldInfo field in staticFields)
        {
            var val = (IntervalType)field.GetValue(null); // null для статических полей
            if (value == val?.Value)
            {
                return val;
            }
        }
        
        return null;
    }
}