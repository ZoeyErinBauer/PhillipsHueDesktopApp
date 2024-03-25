using Flurl.Http;
using HueControlApi.Enum;
using HueControlApi.Models;
using HueControlApi.Utilities;

namespace HueControlApi.API;

public class HueApi(string bridgeUri)
{
    public HueApi(Uri apiUri) : this(apiUri.ToString())
    {
    }

    private FlurlClient CreateHueClient()
    {
        return new FlurlClient(bridgeUri).WithSettings(settings =>
        {
            //TODO: CONFIGURE GETTING SETTINGS FROM APP SETTINGS IN APPLICATION
        });
    }

    /// <summary>
    /// Calls the specified Hue API endpoint and performs the specified API action.
    /// </summary>
    /// <typeparam name="T">Type of response expected.</typeparam>
    /// <param name="endpoint">The API endpoint to call.</param>
    /// <param name="apiAction">The API action to perform (GET, POST, PUT, DELETE).</param>
    /// <param name="lightId">The ID of the light (optional, used for specific light actions).</param>
    /// <param name="postJson">The JSON data for POST or PUT requests (optional).</param>
    /// <returns>A parsed response object containing data responses and error responses.</returns>
    public async Task<ParsedHueResponse<T>> CallHueEndpoint<T>(HueApiEndpoint endpoint,
        ApiAction apiAction, string lightId = "", string postJson = "") where T : IHueModel
    {
        var client = CreateHueClient();
        string result;
        
        switch (apiAction)
        {
            case ApiAction.GET:
                result = lightId.Equals("")
                    ? await client.Request($"{endpoint.ToUrlString()}").GetStringAsync()
                    : await client.Request($"{endpoint.ToUrlString()}/{lightId}").GetStringAsync();
                return HueResponseDecoders.ParseResponseObject<T>(result);
            case ApiAction.POST:
                result = await client.Request($"{endpoint.ToUrlString()}/{lightId}").PostJsonAsync(postJson)
                    .ReceiveString();
                return HueResponseDecoders.ParseResponseObject<T>(result);
            case ApiAction.PUT:
                result = await client.Request($"{endpoint.ToUrlString()}/{lightId}").PutJsonAsync(postJson)
                    .ReceiveString();
                return HueResponseDecoders.ParseResponseObject<T>(result);
            case ApiAction.DELETE:
                result = await client.Request($"{endpoint.ToUrlString()}/{lightId}").PostAsync().ReceiveString();
                return HueResponseDecoders.ParseResponseObject<T>(result);
            default:
                throw new ArgumentOutOfRangeException(nameof(apiAction), apiAction, null);
        }
    }
}