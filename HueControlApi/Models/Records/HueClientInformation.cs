using System.Text.Json.Serialization;

namespace HueControlApi.Models.Records;

public record HueClientInformation([property: JsonPropertyName("username")]
    string Username, [property: JsonPropertyName("clientkey")]
    string ClientKey) : IHueModel;