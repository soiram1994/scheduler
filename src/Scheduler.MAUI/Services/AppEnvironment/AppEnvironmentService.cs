using Scheduler.MAUI.Services.Dialog;
using Scheduler.MAUI.Services.Identity;
using Scheduler.MAUI.Services.Settings;

namespace Scheduler.MAUI.Services.AppEnvironment;

public class AppEnvironmentService(
    IIdentityService identityService,
    IDialogService dialogService,
    ISettingsService settingsService)
    : IAppEnvironmentService
{
    public IIdentityService IdentityService { get; } = identityService;
    public IDialogService DialogService { get; } = dialogService;
    public ISettingsService SettingsService { get; } = settingsService;
}