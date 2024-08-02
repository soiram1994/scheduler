using System.Text.Json;

namespace Scheduler.MAUI.Utilities;

public static class JsonManipulation
{
    public static T? Deserialize<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
    
    
    
}