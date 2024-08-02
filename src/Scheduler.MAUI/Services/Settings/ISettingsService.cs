#nullable enable
namespace Scheduler.MAUI.Services.Settings;

public interface ISettingsService
{
    T? Get<T>(string key);
    void Set<T>(string key, T value);
    void Remove(string key);
    void Clear();
}