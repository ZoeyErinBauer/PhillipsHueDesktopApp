using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.Records;

public record HueClientRegistration([property: JsonPropertyName("devicetype")]
    string DeviceType, [property: JsonPropertyName("generateclientkey")]
    bool GenerateClientKey = true);