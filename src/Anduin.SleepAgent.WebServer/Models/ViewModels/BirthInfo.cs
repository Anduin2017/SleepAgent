using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class BirthInfo
{
    [JsonProperty("year")] public int Year { get; set; }
    [JsonProperty("month")] public int Month { get; set; }
    [JsonProperty("day")] public int Day { get; set; }
}