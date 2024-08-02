using System.Text.Json;

namespace Scheduler.MAUI.Services.Settings;

public class SettingsService() : ISettingsService
{
    public T? Get<T>(string key)
    {
        var result = Preferences.Get(key, "");
        return string.IsNullOrEmpty(result) ? default : JsonSerializer.Deserialize<T>(result);
    }

    public void Set<T>(string key, T value)
    {
        Preferences.Set(key, JsonSerializer.Serialize(value));
    }

    public void Remove(string key)
    {
        Preferences.Remove(key);
    }

    public void Clear()
    {
        Preferences.Clear();
    }
}