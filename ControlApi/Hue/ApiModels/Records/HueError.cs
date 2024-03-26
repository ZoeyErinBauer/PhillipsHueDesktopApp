using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.Records;

public record HueError([property: JsonPropertyName("description")]
    string Description) : IHueModel;