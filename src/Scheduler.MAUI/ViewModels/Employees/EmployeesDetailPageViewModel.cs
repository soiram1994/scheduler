using CommunityToolkit.Mvvm.ComponentModel;
using Scheduler.MAUI.Services.AppEnvironment;
using Scheduler.MAUI.Services.Employees;
using Scheduler.MAUI.Services.Navigation;
using Scheduler.MAUI.ViewModels.Base;

namespace Scheduler.MAUI.ViewModels.Employees;

public class EmployeesDetailPageViewModel(
    INavigationService navigationService,
    IAppEnvironmentService environmentService,
    IEmployeesService employeesService)
    : ViewModelBase(navigationService, environmentService)
{
    private readonly IEmployeesService _employeesService = employeesService;
    
    [ObservableProperty]
    private string Name
}