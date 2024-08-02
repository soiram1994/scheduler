using System.Collections.Generic;
using System.Threading.Tasks;
using eShop.ClientApp.Models.User;
using Microsoft.Maui.Controls;
using Scheduler.MAUI.Models.User;
using Scheduler.MAUI.Services.AppEnvironment;

namespace Scheduler.MAUI.Services.Navigation;

public class NavigationService(IAppEnvironmentService appEnvironmentService) : INavigationService
{
    public async Task InitializeAsync()
    {
        var user = await appEnvironmentService.IdentityService.GetUserInfoAsync();

        await NavigateToAsync(user == UserInfo.Default ? "//Login" : "//Main/");
    }

    public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}