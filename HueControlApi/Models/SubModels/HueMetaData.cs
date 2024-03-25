using System.Text.Json.Serialization;

namespace HueControlApi.Models.SubModels;

[method: JsonConstructor]
public class HueMetaData(string name, string archetype)
{
    [JsonPropertyName("name")] public string Name { get; set; } = name;

    [JsonPropertyName("archetype")] public string Archetype { get; set; } = archetype;
}