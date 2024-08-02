using FluentResults;
using Scheduler.Common.Models;
using Scheduler.MAUI.Clients;

namespace Scheduler.MAUI.Services.Employees;

public class EmployeesService(ISchedulerApiClient schedulerApiClient) : IEmployeesService
{
    public async Task<Result<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {
        return await schedulerApiClient.GetEmployeesAsync();
    }

    public async Task<Result<EmployeeDto>> GetEmployeeAsync(int id)
    {
        return await schedulerApiClient.GetEmployeeAsync(id);
    }

    public async Task<Result<int>> AddEmployeeAsync(EmployeeDto employee)
    {
        return await schedulerApiClient.AddEmployeeAsync(employee);
    }

    public async Task<Result> UpdateEmployeeAsync(EmployeeDto employee)
    {
        return await schedulerApiClient.UpdateEmployeeAsync(employee);
    }

    public async Task<Result> DeleteEmployeeAsync(int id)
    {
        return await schedulerApiClient.DeleteEmployeeAsync(id);
    }
}