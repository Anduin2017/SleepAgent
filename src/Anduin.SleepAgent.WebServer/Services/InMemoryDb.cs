using System.Collections.Concurrent;

namespace Anduin.SleepAgent.WebServer.Services;

public class InMemoryDb
{
    private ConcurrentDictionary<string, object> Data { get; set; } = new();
    
    public object Get(string key)
    {
        return Data.GetOrAdd(key, _ => new object());
    }
    
    public void Set(string key, object data)
    {
        Data[key] = data;
    }
    
    public ICollection<string> GetKeys()
    {
        return Data.Keys;
    }
}