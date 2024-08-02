using Scheduler.MAUI.Services.Navigation;

namespace Scheduler.MAUI;

public partial class App : Application
{
    public App(INavigationService navigationService)
    {
        InitializeComponent();
        MainPage = new AppShell(navigationService);
    }
}