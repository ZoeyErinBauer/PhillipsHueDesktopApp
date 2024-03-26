using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.SubModels;

public class ResourceIdentifier
{
    [JsonPropertyName("rid")] public string ResourceIdentifierId { get; set; }

    [JsonPropertyName("rtype")] public string ResourceType { get; set; }
}