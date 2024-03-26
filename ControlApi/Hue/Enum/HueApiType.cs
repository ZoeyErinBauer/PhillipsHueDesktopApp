namespace ControlApi.Hue.Enum;

public enum HueApiType
{
    LIGHT 
}
public static class HueApiTypeExtensions
{
    public static string ToUrlString(this HueApiType input)
    {
        return input.ToString().ToLower();
    }
}