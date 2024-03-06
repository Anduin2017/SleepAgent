namespace Anduin.SleepAgent.WebServer.Services;

public static class PrometheusFormat
{
    public static string ToPrometheusMetrics(object data)
    {
        var resultDictionary = new Dictionary<string, string>();
        foreach (var property in data.GetType().GetProperties())
        {
            if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
            {
                var value = (DateTime?)property.GetValue(data);
                if (value.HasValue)
                {
                    var unixTime = ((DateTimeOffset)value.Value).ToUnixTimeSeconds();
                    resultDictionary.Add(property.Name, unixTime.ToString());
                }
                else
                {
                    resultDictionary.Add(property.Name, "null");
                }
            }
            else if (property.PropertyType == typeof(string))
            {
                // Convert strings to a quoted string to avoid problems with strings that may look like numbers
                var value = property.GetValue(data)?.ToString() ?? "null";
                resultDictionary.Add(property.Name, $"\"{value}\"");
            }
            else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(float) || property.PropertyType == typeof(double) ||
                     property.PropertyType == typeof(decimal)
                     // add all other numeric types you're planning to use
                    )
            {
                // numeric types can be used as is
                var value = property.GetValue(data)?.ToString() ?? "null";
                resultDictionary.Add(property.Name, value);
            }
            else
            {
                // all other types will be stored as strings
                var value = property.GetValue(data)?.ToString() ?? "null";
                resultDictionary.Add(property.Name, value);
            }
        }
        var result = string.Join("\n", resultDictionary.Select(kv => $"{kv.Key} {kv.Value}"));
        return result;
    }
}