using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class Stress
{
    [JsonProperty("value")] public int Value { get; set; }
    [JsonProperty("time")] public long Time { get; set; }
}