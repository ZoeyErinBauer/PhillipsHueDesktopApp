using System.Text.Json.Serialization;

namespace HueControlApi.Models.Lights;

public class Light(string hueType, string id, string v1Id, HueOwner? owner) : AbstractHueObject
{
    [JsonPropertyName("type")] public sealed override string HueType { get; set; } = hueType;
    [JsonPropertyName("id")] public sealed override string Id { get; set; } = id;
    [JsonPropertyName("id_v1")] public sealed override string V1Id { get; set; } = v1Id;
    [JsonPropertyName("owner")] public HueOwner? Owner { get; set; } = owner;
}