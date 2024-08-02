using Microsoft.Maui.Controls;
using Scheduler.MAUI.Pages.Login;
using Scheduler.MAUI.Services.Navigation;

namespace Scheduler.MAUI;

public partial class AppShell : Shell
{
    private INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeComponent();
    }

    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }
}