using FluentResults;
using Scheduler.Common.Models;

namespace Scheduler.MAUI.Services.Employees;

public interface IEmployeesService
{
    Task<Result<IEnumerable<EmployeeDto>>> GetEmployeesAsync();
    Task<Result<EmployeeDto>> GetEmployeeAsync(int id);
    Task<Result<int>> AddEmployeeAsync(EmployeeDto employee);
    Task<Result> UpdateEmployeeAsync(EmployeeDto employee);
    Task<Result> DeleteEmployeeAsync(int id);
}