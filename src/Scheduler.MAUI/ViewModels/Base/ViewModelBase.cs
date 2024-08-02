using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Scheduler.MAUI.Services.AppEnvironment;
using Scheduler.MAUI.Services.Navigation;

namespace Scheduler.MAUI.ViewModels.Base;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    private long _isBusy;

    [ObservableProperty] private bool _isInitialized;

    public ViewModelBase(INavigationService navigationService, IAppEnvironmentService environmentService)
    {
        NavigationService = navigationService;
        EnvironmentService = environmentService;

        InitializeAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

    public INavigationService NavigationService { get; }

    public IAppEnvironmentService EnvironmentService { get; }

    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    protected async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}