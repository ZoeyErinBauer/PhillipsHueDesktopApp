using ControlApi.Hue.ApiModels.Records;
using ControlApi.Hue.Utilities;

namespace HueControlApiTests.UtilityTests;

public class HueResponseDecodersTests
{
    private const string SuccessfulClientResponse =
        "[\n  {\n    \"success\": {\n      \"username\": \"asasdasdfljoi32098fkljasoije030ed89\",\n      \"clientkey\": \"asdlk23w879uihjalfwiejhu3hnr9o8ihynvhuj32\"\n    }\n  }\n]";

    private static readonly HueClientInformation SuccessfulClientInformation =
        new HueClientInformation("asasdasdfljoi32098fkljasoije030ed89", "asdlk23w879uihjalfwiejhu3hnr9o8ihynvhuj32");

    [Fact]
    public void TestParseHueClientInformation()
    {
        var result = HueResponseDecoders.ParseResponseArray<HueClientInformation>(SuccessfulClientResponse);
        Assert.Equal(SuccessfulClientInformation, result);
    }
}