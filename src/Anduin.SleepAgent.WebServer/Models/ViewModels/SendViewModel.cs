using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class SendViewModel
{
    [JsonProperty("recordTime")] public long RecordTime { get; set; }
    [JsonProperty("user")] public User User { get; set; } = new();
    [JsonProperty("device")] public Device Device { get; set; } = new();
    [JsonProperty("heartRateLast")] public int HeartRateLast { get; set; }
    [JsonProperty("heartRateResting")] public int HeartRateResting { get; set; }
    [JsonProperty("heartRateSummary")] public HeartRateSummary HeartRateSummary { get; set; } = new();
    [JsonProperty("battery")] public int Battery { get; set; }
    [JsonProperty("bloodOxygen")] public BloodOxygen BloodOxygen { get; set; } = new();
    [JsonProperty("calorie")] public int Calorie { get; set; }
    [JsonProperty("calorieT")] public int CalorieT { get; set; }
    [JsonProperty("distance")] public int Distance { get; set; }
    [JsonProperty("fatBurning")] public int FatBurning { get; set; }
    [JsonProperty("fatBurningT")] public int FatBurningT { get; set; }
    [JsonProperty("paiDay")] public int PaiDay { get; set; }
    [JsonProperty("paiWeek")] public int PaiWeek { get; set; }
    [JsonProperty("sleepInfo")] public SleepInfo SleepInfo { get; set; } = new();
    [JsonProperty("sleepStgList")] public SleepStageList SleepStgList { get; set; } = new();
    [JsonProperty("sleepingStatus")] public int SleepingStatus { get; set; }
    [JsonProperty("stands")] public int Stands { get; set; }
    [JsonProperty("standsT")] public int StandsT { get; set; }
    [JsonProperty("steps")] public int Steps { get; set; }
    [JsonProperty("stepsT")] public int StepsT { get; set; }
    [JsonProperty("stress")] public Stress Stress { get; set; } = new();
    [JsonProperty("isWearing")] public int IsWearing { get; set; }
}