using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class Maximum
{
    [JsonProperty("time")] public long Time { get; set; }
    [JsonProperty("time_zone")] public int TimeZone { get; set; }
    [JsonProperty("hr_value")] public int HrValue { get; set; }
}