using System.Text.Json.Serialization;

namespace HueControlApi.Models.Records;

public record HueClientRegistration([property: JsonPropertyName("devicetype")]
    string DeviceType, [property: JsonPropertyName("generateclientkey")]
    bool GenerateClientKey = true);