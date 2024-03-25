using System.Text.Json.Serialization;

namespace HueControlApi.Models;

public abstract class AbstractHueObject : IHueModel
{
    [JsonPropertyName("type")] public abstract string HueType { get; set; }

    [JsonPropertyName("id")] public abstract string Id { get; set; }

    [JsonPropertyName("id_v1")] public abstract string V1Id { get; set; }
}