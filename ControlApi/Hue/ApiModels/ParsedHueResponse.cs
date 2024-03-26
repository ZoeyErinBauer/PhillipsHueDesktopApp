using ControlApi.Hue.ApiModels.Records;


namespace ControlApi.Hue.ApiModels;

/// <summary>
/// Stores parsed information from the Phillips hue api call as a Typed Data response and HueError Objects
/// </summary>
/// <param name="dataResponses"></param>
/// <param name="errorResponses"></param>
/// <typeparam name="T">Type of Response Expected</typeparam>
public class ParsedHueResponse<T>(IEnumerable<T> dataResponses, IEnumerable<HueError> errorResponses)
    where T : IHueModel
{
    public IEnumerable<T> DataResponses = dataResponses;

    public IEnumerable<HueError> ErrorResponses = errorResponses;
}