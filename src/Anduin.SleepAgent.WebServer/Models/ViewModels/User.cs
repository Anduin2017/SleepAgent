using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class User
{
    [JsonProperty("age")] public int Age { get; set; }
    [JsonProperty("height")] public double Height { get; set; }
    [JsonProperty("weight")] public double Weight { get; set; }
    [JsonProperty("gender")] public int Gender { get; set; }
    [JsonProperty("nickName")] public string NickName { get; set; } = string.Empty;
    [JsonProperty("region")] public string Region { get; set; } = string.Empty;
    [JsonProperty("birth")] public BirthInfo Birth { get; set; } = new();
}