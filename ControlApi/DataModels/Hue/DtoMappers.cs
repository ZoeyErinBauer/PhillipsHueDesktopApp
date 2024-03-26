using ControlApi.Hue.ApiModels.Records;

namespace ControlApi.DataModels.Hue;

public static class DtoMappers
{
    public static ClientInformation MapToDatabase(this HueClientInformation input)
    {
        return new ClientInformation(Id: 0, Username: input.Username,
            ClientKey: input.ClientKey, IsActive: true);
    }

    public static ApplicationModels.Hue.ClientInformation MapToClient(
        this ApplicationModels.Hue.ClientInformation input)
    {
        return new ApplicationModels.Hue.ClientInformation(input.Id, input.Username, input.ClientKey, input.IsActive);
    }
}