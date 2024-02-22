using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class HeartRateSummary
{
    [JsonProperty("maximum")] public Maximum Maximum { get; set; } = new();
}