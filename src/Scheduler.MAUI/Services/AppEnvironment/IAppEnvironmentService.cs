using Scheduler.MAUI.Services.Dialog;
using Scheduler.MAUI.Services.Identity;
using Scheduler.MAUI.Services.Settings;

namespace Scheduler.MAUI.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    IIdentityService IdentityService { get; }
    IDialogService DialogService { get; }
    ISettingsService SettingsService { get; }
}