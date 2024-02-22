using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class SleepInfo
{
    [JsonProperty("score")] public int Score { get; set; }
    [JsonProperty("startTime")] public int StartTime { get; set; }
    [JsonProperty("endTime")] public int EndTime { get; set; }
    [JsonProperty("deepTime")] public int DeepTime { get; set; }
    [JsonProperty("totalTime")] public int TotalTime { get; set; }
}