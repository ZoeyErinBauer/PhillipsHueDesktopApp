using System.Text.Json.Serialization;

namespace HueControlApi.Models;

[method: JsonConstructor]
public class HueOwner(string rid, string rtype)
{
    [JsonPropertyName("rid")] public string ResourceId { get; set; } = rid;
    [JsonPropertyName("rtype")] public string ResourceType { get; set; } = rtype;
}