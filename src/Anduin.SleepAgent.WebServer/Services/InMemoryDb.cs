using System.Collections.Concurrent;
using Anduin.SleepAgent.WebServer.Models.ViewModels;

namespace Anduin.SleepAgent.WebServer.Services;

public class InMemoryDb
{
    private ConcurrentDictionary<string, SendViewModel> Data { get; set; } = new();
    
    public object Get(string key)
    {
        return Data.GetOrAdd(key, _ => new SendViewModel());
    }
    
    public void Set(string key, SendViewModel data)
    {
        Data[key] = data;
    }
    
    public ICollection<string> GetKeys()
    {
        return Data.Keys;
    }
}