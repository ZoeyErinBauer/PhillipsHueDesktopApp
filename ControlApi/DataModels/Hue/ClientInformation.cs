using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControlApi.DataModels.Hue;

public record ClientInformation(
    [property: Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    int Id,
    [property: Column] string Username,
    [property: Column] string ClientKey,
    [property: Column] bool IsActive);