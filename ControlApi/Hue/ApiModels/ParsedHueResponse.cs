using ControlApi.Hue.ApiModels.Records;


namespace ControlApi.Hue.ApiModels;

/// <summary>
/// Stores parsed information from the Phillips hue api call as a Typed Data response and HueError Objects
/// </summary>
/// <typeparam name="T">Type of Response Expected</typeparam>
public class ParsedHueResponse<T> where T : IHueModel
{
    public IEnumerable<T> DataResponses;

    public IEnumerable<HueError> ErrorResponses;

    /// <summary>
    /// Stores parsed information from the Phillips hue api call as a Typed Data response and HueError Objects
    /// </summary>
    /// <param name="dataResponses"></param>
    /// <param name="errorResponses"></param>
    /// <typeparam name="T">Type of Response Expected</typeparam>
    public ParsedHueResponse(IEnumerable<T> dataResponses, IEnumerable<HueError> errorResponses)
    {
        DataResponses = dataResponses;
        ErrorResponses = errorResponses;
    }
}