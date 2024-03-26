using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.Records;

public record HueClientInformation([property: JsonPropertyName("username")]
    string Username, [property: JsonPropertyName("clientkey")]
    string ClientKey) : IHueModel;