using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class SleepStageList
{
    [JsonProperty("WAKE_STAGE")] public int WakeStage { get; set; }
    [JsonProperty("REM_STAGE")] public int RemStage { get; set; }
    [JsonProperty("LIGHT_STAGE")] public int LightStage { get; set; }
    [JsonProperty("DEEP_STAGE")] public int DeepStage { get; set; }
}