using System.Runtime.CompilerServices;

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string val) => string.IsNullOrWhiteSpace(val);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string val) => string.IsNullOrEmpty(val);
}