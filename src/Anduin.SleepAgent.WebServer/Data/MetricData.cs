using System.ComponentModel.DataAnnotations;

namespace Anduin.SleepAgent.WebServer.Data;

public class MetricData
{
    [Key]
    public int Id { get; set; }
    public DateTime RecordTime { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public int Gender { get; set; }
    [MaxLength(100)]
    public string NickName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Region { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    public int BirthMonth { get; set; }
    public int BirthDay { get; set; }
    public int DeviceWidth { get; set; }
    public int DeviceHeight { get; set; }
    public int ScreenShape { get; set; }
    [MaxLength(100)]
    public string DeviceName { get; set; } = string.Empty;
    public int KeyNumber { get; set; }
    [MaxLength(100)]
    public string KeyType { get; set; } = string.Empty;
    public int DeviceSource { get; set; }
    public int DeviceColor { get; set; }
    public int ProductId { get; set; }
    public int ProductVer { get; set; }
    public int SkuId { get; set; }
    public int HeartRateLast { get; set; }
    public int HeartRateResting { get; set; }
    public long HeartRateSummaryMaximumTime { get; set; }
    public int HeartRateSummaryMaximumTimeZone { get; set; }
    public int HeartRateSummaryMaximumHrValue { get; set; }
    public int Battery { get; set; }
    public int BloodOxygenValue { get; set; }
    public long BloodOxygenTime { get; set; }
    public int BloodOxygenRetCode { get; set; }
    public int Calorie { get; set; }
    public int CalorieT { get; set; }
    public int Distance { get; set; }
    public int FatBurning { get; set; }
    public int FatBurningT { get; set; }
    public int PaiDay { get; set; }
    public int PaiWeek { get; set; }
    public int SleepInfoScore { get; set; }
    public int SleepInfoStartTime { get; set; }
    public int SleepInfoEndTime { get; set; }
    public int SleepInfoDeepTime { get; set; }
    public int SleepInfoTotalTime { get; set; }
    public int SleepStgListWakeStage { get; set; }
    public int SleepStgListRemStage { get; set; }
    public int SleepStgListLightStage { get; set; }
    public int SleepStgListDeepStage { get; set; }
    public int SleepingStatus { get; set; }
    public int Stands { get; set; }
    public int StandsT { get; set; }
    public int Steps { get; set; }
    public int StepsT { get; set; }
    public int StressValue { get; set; }
    public long StressTime { get; set; }
    public int IsWearing { get; set; }
}