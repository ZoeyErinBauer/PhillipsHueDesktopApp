using Xunit;
using Moq;
using System.Threading.Tasks;
using ControlApi.Hue.API;
using Flurl.Http.Testing;
using ControlApi.Hue.ApiModels;
using ControlApi.Hue.Enum;

public class HueApiTests
{
    [Fact]
    public async Task CallHueEndpoint_GET_ValidLightId_ReturnsExpectedTypeResponse()
    {
        // Arrange
        var flurlHttpTest = new HttpTest();
        const string bridgeUri = "http://localhost";
        const string lightId = "1";
        const string mockedResponse =
            "{\n  \"errors\": [],\n  \"data\": [\n    {\n      \"type\": \"HueTypeSample\",\n      \"id\": \"DeviceIDSample\",\n      \"id_v1\": \"V1IdSample\",\n      \"product_data\": {\n        \"model_id\": \"ModelIdSample\",\n        \"manufacturer_name\": \"ManufacturerSample\",\n        \"product_name\": \"ProductNameSample\",\n        \"product_archetype\": \"ProductArchetypeSample\",\n        \"certified\": true,\n        \"software_version\": \"SoftwareVersionSample\",\n        \"hardware_platform_type\": \"HardwarePlatformTypeSample\"\n      },\n      \"metadata\": {\n        \"name\": \"NameSample\",\n        \"archetype\": \"ArchetypeSample\"\n      },\n      \"usertest\": {\n        \"status\": \"StatusSample\",\n        \"usertest\": true\n      },\n      \"services\": [\n        {\n          \"rid\": \"ResourceIdentifierIdSample\",\n          \"rtype\": \"ResourceTypeSample\"\n        }\n      ]\n    }\n  ]\n}";
        flurlHttpTest.RespondWith(body: mockedResponse);

        var hueApi = new HueApi(bridgeUri);

        // Act
        var result = await hueApi.CallHueEndpoint<Device>(HueApiEndpoint.LIGHT, ApiAction.GET, lightId);

        // Assert
        flurlHttpTest.ShouldHaveCalled($"*/light/{lightId}");
        Assert.NotNull(result);
        Assert.NotEmpty(result.DataResponses);
    }

    // TODO: Add more tests for POST, PUT, DELETE actions and for error conditions.
}