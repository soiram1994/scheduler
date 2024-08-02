using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Scheduler.MAUI.Services.Navigation;

namespace Scheduler.MAUI.ViewModels.Base;

public interface IViewModelBase : IQueryAttributable
{
    public INavigationService NavigationService { get; }

    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; }

    Task InitializeAsync();
}
