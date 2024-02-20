namespace Anduin.SleepAgent.WebServer.Services;

public class InMemoryDb
{
    private object Data { get; set; } = new();
    
    public object Get()
    {
        return Data;
    }
    
    public void Set(object data)
    {
        lock (Data)
        {
            Data = data;
        }
    }
}