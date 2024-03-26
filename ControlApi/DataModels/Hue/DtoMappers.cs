using ControlApi.Hue.ApiModels.Records;

namespace HueControlApi.DataModels.Hue;

public static class DtoMappers
{
    public static ClientInformation MapToDatabase(this HueClientInformation input)
    {
        return new ClientInformation(Id: 0, Username: input.Username,
            ClientKey: input.ClientKey, IsActive: true);
    }
    
    
    
}