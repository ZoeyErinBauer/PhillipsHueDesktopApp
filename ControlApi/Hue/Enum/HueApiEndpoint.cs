namespace ControlApi.Hue.Enum;

public enum HueApiEndpoint
{
    LIGHT,
    DEVICE
}

public static class HueApiEndpointExtensions
{
    public static string ToUrlString(this HueApiEndpoint input)
    {
        return input.ToString().ToLower();
    }
}