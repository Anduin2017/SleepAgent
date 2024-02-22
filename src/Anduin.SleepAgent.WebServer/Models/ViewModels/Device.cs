using Newtonsoft.Json;

namespace Anduin.SleepAgent.WebServer.Models.ViewModels;

public class Device
{
    [JsonProperty("width")] public int Width { get; set; }
    [JsonProperty("height")] public int Height { get; set; }
    [JsonProperty("screenShape")] public int ScreenShape { get; set; }
    [JsonProperty("deviceName")] public string DeviceName { get; set; } = string.Empty;
    [JsonProperty("keyNumber")] public int KeyNumber { get; set; }
    [JsonProperty("keyType")] public string KeyType { get; set; } = string.Empty;
    [JsonProperty("deviceSource")] public int DeviceSource { get; set; }
    [JsonProperty("deviceColor")] public int DeviceColor { get; set; }
    [JsonProperty("productId")] public int ProductId { get; set; }
    [JsonProperty("productVer")] public int ProductVer { get; set; }
    [JsonProperty("skuId")] public int SkuId { get; set; }
}