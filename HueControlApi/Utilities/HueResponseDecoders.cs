using System.Text.Json;
using HueControlApi.Models;
using HueControlApi.Models.Records;

namespace HueControlApi.Utilities;

public static class HueResponseDecoders
{
    public static ParsedHueResponse<T> ParseResponseObject<T>(string jsonString) where T : IHueModel
    {
        var document = JsonDocument.Parse(jsonString);
        var objects = new List<T>();
        var errors = new List<HueError>();

        foreach (var element in document.RootElement.EnumerateObject())
        {
            switch (element.Name)
            {
                case "errors":
                    var errorElements = element.Value.EnumerateArray();
                    if (errorElements.Any())
                    {
                        foreach (var error in errorElements)
                        {
                            var parsedError = error.Deserialize<HueError>();
                            if (parsedError == null) throw new JsonException($"Failed to parsed {error.ToString()}");
                            errors.Add(parsedError);
                            //TODO: ADD BETTER LOGGING FOR HANDLING THIS THROWING ERROR FOR NOW AS THERE WAS A MORE IMPORTANT ERROR THAN FAILING TO PARSE
                        }
                    }

                    break;
                case "data":
                    var dataElements = element.Value.EnumerateArray();
                    if (dataElements.Any())
                    {
                        foreach (var dataElement in dataElements)
                        {
                            var parsed = dataElement.Deserialize<T>();
                            if (parsed != null)
                            {
                                objects.Add(parsed);
                                continue;
                            }

                            //TODO:ADD BETTER LOGGING FOR TRACKING FAILED PARSING
                            Console.WriteLine($"Failed Deserialize for {dataElement.ToString()}");
                        }
                    }

                    break;
                default:
                    throw new JsonException("Invalid Json Object");
            }
        }

        return new ParsedHueResponse<T>(objects, errors);
    }

    public static T ParseResponseArray<T>(string jsonString) where T : IHueModel
    {
        var document = JsonDocument.Parse(jsonString);
        foreach (var subElement in document.RootElement.EnumerateArray().SelectMany(element =>
                     element.EnumerateObject().Where(subElement => subElement.Name.Equals("success"))))
        {
            return subElement.Value.Deserialize<T>() ?? throw new JsonException("Failed to parse json object");
        }

        throw new JsonException("Failed to parse json array");
    }
}