namespace Core;

public static class Extensions
{
    public static bool IsEmpty(this string value) => 
        string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

    public static bool IsInRange(this byte value, byte a, byte b) => value >= a && value <= b;
}