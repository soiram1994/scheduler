using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Scheduler.Common.Models;
using Scheduler.MAUI.Clients;
using Scheduler.MAUI.Services.AppEnvironment;
using Scheduler.MAUI.Services.Navigation;
using Scheduler.MAUI.ViewModels.Base;

namespace Scheduler.MAUI.ViewModels.Employees;

public partial class EmployeeListPageViewModel(
    INavigationService navigationService,
    IAppEnvironmentService environmentService,
    ISchedulerApiClient client) : ViewModelBase(navigationService, environmentService)
{
    [ObservableProperty] private string _title = "Employees";
    [ObservableProperty] private ObservableCollection<EmployeeDto> _employees = null!;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        await IsBusyFor(async () =>
        {
            var result = await client.GetEmployeesAsync();
            if (result.IsFailed)
            {
                await EnvironmentService.DialogService.ShowAlertAsync(result.Errors.First().Message, "Error", "Ok");
                return;
            }

            Employees = new ObservableCollection<EmployeeDto>(result.Value);
        });
    }
}