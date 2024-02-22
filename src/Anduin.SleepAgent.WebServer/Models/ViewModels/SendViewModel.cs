using Anduin.SleepAgent.WebServer.Data;
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

    public MetricData ToMetricData()
    {
        return new MetricData
        {
            RecordTime = new DateTime(RecordTime),
            Age = User.Age,
            Height = User.Height,
            Weight = User.Weight,
            Gender = User.Gender,
            NickName = User.NickName,
            Region = User.Region,
            BirthYear = User.Birth.Year,
            BirthMonth = User.Birth.Month,
            BirthDay = User.Birth.Day,
            DeviceWidth = Device.Width,
            DeviceHeight = Device.Height,
            ScreenShape = Device.ScreenShape,
            DeviceName = Device.DeviceName,
            KeyNumber = Device.KeyNumber,
            KeyType = Device.KeyType,
            DeviceSource = Device.DeviceSource,
            DeviceColor = Device.DeviceColor,
            ProductId = Device.ProductId,
            ProductVer = Device.ProductVer,
            SkuId = Device.SkuId,
            HeartRateLast = HeartRateLast,
            HeartRateResting = HeartRateResting,
            HeartRateSummaryMaximumTime = HeartRateSummary.Maximum.Time,
            HeartRateSummaryMaximumTimeZone = HeartRateSummary.Maximum.TimeZone,
            HeartRateSummaryMaximumHrValue = HeartRateSummary.Maximum.HrValue,
            Battery = Battery,
            BloodOxygenValue = BloodOxygen.Value,
            BloodOxygenTime = BloodOxygen.Time,
            BloodOxygenRetCode = BloodOxygen.RetCode,
            Calorie = Calorie,
            CalorieT = CalorieT,
            Distance = Distance,
            FatBurning = FatBurning,
            FatBurningT = FatBurningT,
            PaiDay = PaiDay,
            PaiWeek = PaiWeek,
            SleepInfoScore = SleepInfo.Score,
            SleepInfoStartTime = SleepInfo.StartTime,
            SleepInfoEndTime = SleepInfo.EndTime,
            SleepInfoDeepTime = SleepInfo.DeepTime,
            SleepInfoTotalTime = SleepInfo.TotalTime,
            SleepStgListWakeStage = SleepStgList.WakeStage,
            SleepStgListRemStage = SleepStgList.RemStage,
            SleepStgListLightStage = SleepStgList.LightStage,
            SleepStgListDeepStage = SleepStgList.DeepStage,
            SleepingStatus = SleepingStatus,
            Stands = Stands,
            StandsT = StandsT,
            Steps = Steps,
            StepsT = StepsT,
            StressValue = Stress.Value,
            StressTime = Stress.Time,
            IsWearing = IsWearing
        };
    }
}

// public class MetricData
// {
//     [Key]
//     public int Id { get; set; }
//     public DateTime RecordTime { get; set; }
//     public int Age { get; set; }
//     public double Height { get; set; }
//     public double Weight { get; set; }
//     public int Gender { get; set; }
//     [MaxLength(100)]
//     public string NickName { get; set; } = string.Empty;
//     [MaxLength(100)]
//     public string Region { get; set; } = string.Empty;
//     public int BirthYear { get; set; }
//     public int BirthMonth { get; set; }
//     public int BirthDay { get; set; }
//     public int DeviceWidth { get; set; }
//     public int DeviceHeight { get; set; }
//     public int ScreenShape { get; set; }
//     [MaxLength(100)]
//     public string DeviceName { get; set; } = string.Empty;
//     public int KeyNumber { get; set; }
//     [MaxLength(100)]
//     public string KeyType { get; set; } = string.Empty;
//     public int DeviceSource { get; set; }
//     public int DeviceColor { get; set; }
//     public int ProductId { get; set; }
//     public int ProductVer { get; set; }
//     public int SkuId { get; set; }
//     public int HeartRateLast { get; set; }
//     public int HeartRateResting { get; set; }
//     public long HeartRateSummaryMaximumTime { get; set; }
//     public int HeartRateSummaryMaximumTimeZone { get; set; }
//     public int HeartRateSummaryMaximumHrValue { get; set; }
//     public int Battery { get; set; }
//     public int BloodOxygenValue { get; set; }
//     public long BloodOxygenTime { get; set; }
//     public int BloodOxygenRetCode { get; set; }
//     public int Calorie { get; set; }
//     public int CalorieT { get; set; }
//     public int Distance { get; set; }
//     public int FatBurning { get; set; }
//     public int FatBurningT { get; set; }
//     public int PaiDay { get; set; }
//     public int PaiWeek { get; set; }
//     public int SleepInfoScore { get; set; }
//     public int SleepInfoStartTime { get; set; }
//     public int SleepInfoEndTime { get; set; }
//     public int SleepInfoDeepTime { get; set; }
//     public int SleepInfoTotalTime { get; set; }
//     public int SleepStgListWakeStage { get; set; }
//     public int SleepStgListRemStage { get; set; }
//     public int SleepStgListLightStage { get; set; }
//     public int SleepStgListDeepStage { get; set; }
//     public int SleepingStatus { get; set; }
//     public int Stands { get; set; }
//     public int StandsT { get; set; }
//     public int Steps { get; set; }
//     public int StepsT { get; set; }
//     public int StressValue { get; set; }
//     public long StressTime { get; set; }
//     public int IsWearing { get; set; }
// }