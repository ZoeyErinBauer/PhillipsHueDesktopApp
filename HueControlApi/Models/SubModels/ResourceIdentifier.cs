using System.Text.Json.Serialization;

namespace HueControlApi.Models.SubModels;

[method: JsonConstructor]
public class ResourceIdentifier
{
    [JsonPropertyName("rid")] public string ResourceIdentifierId { get; set; }

    [JsonPropertyName("rtype")] public string ResourceType { get; set; }
}