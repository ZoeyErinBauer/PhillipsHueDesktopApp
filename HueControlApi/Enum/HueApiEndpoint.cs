﻿namespace HueControlApi.Enum;

public enum HueApiEndpoint
{
    LIGHT
}

public static class HueApiEndpointExtensions
{
    public static string ToUrlString(this HueApiEndpoint input)
    {
        return input.ToString().ToLower();
    }
}