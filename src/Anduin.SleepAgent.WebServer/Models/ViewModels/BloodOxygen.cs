using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class BloodOxygen
{
    [JsonProperty("value")] public int Value { get; set; }
    [JsonProperty("time")] public int Time { get; set; }
    [JsonProperty("retCode")] public int RetCode { get; set; }
}