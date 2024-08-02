using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.MAUI.Services.Navigation;

public interface INavigationService
{
    Task InitializeAsync();

    Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);

    Task PopAsync();
}
