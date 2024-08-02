using Scheduler.MAUI.Pages.Login;
using Scheduler.MAUI.Services.AppEnvironment;
using Scheduler.MAUI.Services.Dialog;
using Scheduler.MAUI.Services.Employees;
using Scheduler.MAUI.Services.Identity;
using Scheduler.MAUI.Services.Navigation;
using Scheduler.MAUI.Services.Settings;
using Scheduler.MAUI.Services.Skills;
using Scheduler.MAUI.ViewModels.Login;

namespace Scheduler.MAUI;

public static class DependencyInjectionHelper
{
    public static IServiceCollection AddSchedulerServices(this IServiceCollection services)
        => services
            .AddUtilities()
            .AddApplicationServices();

    public static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<ISettingsService, SettingsService>()
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IIdentityService, IdentityMockService>()
            .AddSingleton<IAppEnvironmentService, AppEnvironmentService>();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ISkillsService, SkillsService>();
        services.AddSingleton<IEmployeesService, EmployeesService>();
        services.AddSingleton<INavigationService, NavigationService>();
        return services;
    }
    
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<LoginPageViewModel>();
        return services;
    }
    
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<LoginPage>();
        return services;
    }
}