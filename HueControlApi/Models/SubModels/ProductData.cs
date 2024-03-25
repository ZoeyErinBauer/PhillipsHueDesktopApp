using System.Text.Json.Serialization;

namespace HueControlApi.Models.SubModels;

public class ProductData
{
    [JsonPropertyName("model_id")] public string ModelId { get; set; }

    [JsonPropertyName("manufacturer_name")]
    public string ManufacturerName { get; set; }

    [JsonPropertyName("product_name")] public string ProductName { get; set; }

    [JsonPropertyName("product_archetype")]
    public string ProductArchetype { get; set; }

    [JsonPropertyName("certified")] public bool Certified { get; set; }

    [JsonPropertyName("software_version")] public string SoftwareVersion { get; set; }

    [JsonPropertyName("hardware_platform_type")]
    public string HardwarePlatformType { get; set; }
}