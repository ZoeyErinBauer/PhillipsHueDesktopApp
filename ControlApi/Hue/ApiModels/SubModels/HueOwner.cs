using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.SubModels;

[method: JsonConstructor]
public class HueOwner(string rid, string rtype)
{
    [JsonPropertyName("rid")] public string ResourceId { get; set; } = rid;
    [JsonPropertyName("rtype")] public string ResourceType { get; set; } = rtype;
}