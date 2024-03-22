using System.Text.Json.Serialization;

namespace HueControlApi.Models.Records;

public record HueError([property: JsonPropertyName("description")]
    string Description) : IHueModel;