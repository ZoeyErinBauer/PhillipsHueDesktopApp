using System.Text.Json.Serialization;

namespace HueControlApi.DataModels.Hue;

public record ClientInformation(
    [property: JsonPropertyName("Id")] int Id,
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("clientkey")]
    string ClientKey,
    [property: JsonPropertyName("isActive")]
    bool IsActive);