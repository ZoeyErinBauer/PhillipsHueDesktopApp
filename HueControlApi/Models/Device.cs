using System.Text.Json.Serialization;
using HueControlApi.Models.SubModels;

namespace HueControlApi.Models;

public class Device : AbstractHueObject
{
    public Device(string hueType, string id, string v1Id, ProductData productData, HueMetaData metaData, UserTest userTest, List<ResourceIdentifier> services)
    {
        HueType = hueType;
        Id = id;
        V1Id = v1Id;
        ProductData = productData;
        MetaData = metaData;
        UserTest = userTest;
        Services = services;
    }

    [JsonPropertyName("type")] public override string HueType { get; set; }

    [JsonPropertyName("id")] public override string Id { get; set; }

    [JsonPropertyName("id_v1")] public override string V1Id { get; set; }

    [JsonPropertyName("product_data")] public ProductData ProductData { get; set; }

    [JsonPropertyName("metadata")] public HueMetaData MetaData { get; set; }

    [JsonPropertyName("usertest")] public UserTest UserTest { get; set; }

    [JsonPropertyName("services")] public List<ResourceIdentifier> Services { get; set; }
}