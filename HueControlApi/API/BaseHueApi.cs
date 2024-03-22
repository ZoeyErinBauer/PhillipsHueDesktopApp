using Flurl.Http;

namespace HueControlApi.API;

public abstract class BaseHueApi
{
    private readonly string _bridgeUri;

    protected BaseHueApi(string bridgeUri, string endpointUri)
    {
        _bridgeUri = bridgeUri + endpointUri;
    }

    protected BaseHueApi(Uri apiUri)
    {
        _bridgeUri = apiUri.ToString();
    }

    protected FlurlClient CreateHueClient()
    {
        return new FlurlClient(_bridgeUri).WithSettings(settings =>
        {
            //TODO: CONFIGURE GETTING SETTINGS FROM APP SETTINGS IN APPLICATION
        });
    }
}