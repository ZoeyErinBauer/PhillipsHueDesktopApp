﻿using System.Text.Json.Serialization;

namespace ControlApi.Hue.ApiModels.SubModels;

public class UserTest
{
    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("usertest")] public bool IsUserTest { get; set; }
}