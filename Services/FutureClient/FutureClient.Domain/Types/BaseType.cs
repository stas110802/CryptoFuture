namespace FutureClient.Domain.Types;

public abstract class BaseType
{
    protected BaseType(string value)
    {
        Value = value;
    }

    public string Value { get; }
}