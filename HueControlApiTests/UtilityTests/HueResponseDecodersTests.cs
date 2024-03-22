using HueControlApi.Models.Records;
using HueControlApi.Utilities;

namespace HueControlApiTests.UtilityTests;

public class HueResponseDecodersTests
{
    private const string successfulClientResponse = "";

    [Fact]
    public void TestParseHueClientInformation()
    {
        HueResponseDecoders.ParseResponseArray<HueClientInformation>(successfulClientResponse);
        Assert.True(true);
    }
}