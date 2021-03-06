public class SafeString
{
    public readonly string Value;
    public SafeString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new System.ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }
        Value = value;
    }

    public static implicit operator string(SafeString safeString)
    {
        return safeString.Value;
    } 

    public override string ToString()
    {
        return Value;
    }
}