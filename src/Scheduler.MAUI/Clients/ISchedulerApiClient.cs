using System.Net.Http.Json;
using FluentResults;
using Scheduler.Common.Models;

namespace Scheduler.MAUI.Clients;

public interface ISchedulerApiClient
{
    Task<Result<EmployeeDto>> GetEmployeeAsync(int id);
    Task<Result<IEnumerable<EmployeeDto>>> GetEmployeesAsync();
    Task<Result<IEnumerable<SkillDto>>> GetSkillsAsync();
    Task<Result<SkillDto>> GetSkillAsync(int id);
    Task<Result<int>> AddEmployeeAsync(EmployeeDto employee);
    Task<Result> UpdateEmployeeAsync(EmployeeDto employee);
    Task<Result> DeleteEmployeeAsync(int id);
    Task<Result> AddSkillAsync(SkillDto skill);
    Task<Result> UpdateSkillAsync(SkillDto skill);
    Task<Result> DeleteSkillAsync(int id);
}

public class SchedulerApiClient : ISchedulerApiClient
{
    private readonly HttpClient _httpClient;

    public SchedulerApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<Result<HttpResponseMessage>> SendMessageAsync(
        Func<Task<HttpResponseMessage>> request)
    {
        try
        {
            var response = await request();
            return !response.IsSuccessStatusCode
                ? Result.Fail(await response.Content.ReadAsStringAsync())
                : Result.Ok(response);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public async Task<Result<EmployeeDto>> GetEmployeeAsync(int id)
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync($"employees/{id}"));
        if (result.IsFailed)
        {
            return Result.Fail<EmployeeDto>(result.Errors);
        }

        var employee = await result.Value.Content.ReadFromJsonAsync<EmployeeDto>();
        return Result.Ok(employee)!;
    }

    public async Task<Result<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync("employees"));
        if (result.IsFailed)
        {
            return Result.Fail<IEnumerable<EmployeeDto>>(result.Errors);
        }

        var employees = await result.Value.Content.ReadFromJsonAsync<IEnumerable<EmployeeDto>>();
        return Result.Ok(employees)!;
    }

    public async Task<Result<IEnumerable<SkillDto>>> GetSkillsAsync()
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync("skills"));
        if (result.IsFailed)
        {
            return Result.Fail<IEnumerable<SkillDto>>(result.Errors);
        }

        var skills = await result.Value.Content.ReadFromJsonAsync<IEnumerable<SkillDto>>();
        return Result.Ok(skills)!;
    }

    public async Task<Result<SkillDto>> GetSkillAsync(int id)
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync($"skills/{id}"));
        if (result.IsFailed)
        {
            return Result.Fail<SkillDto>(result.Errors);
        }

        var skill = await result.Value.Content.ReadFromJsonAsync<SkillDto>();
        return Result.Ok(skill)!;
    }

    public async Task<Result<int>> AddEmployeeAsync(EmployeeDto employee)
    {
        var result = await SendMessageAsync(
            () => _httpClient.PostAsJsonAsync("employees", employee));
        if (result.IsFailed)
        {
            return Result.Fail<int>(result.Errors);
        }

        var id = await result.Value.Content.ReadFromJsonAsync<int>();
        return Result.Ok(id)!;
    }

    public async Task<Result> UpdateEmployeeAsync(EmployeeDto employee)
    {
        var result = await SendMessageAsync(
            () => _httpClient.PutAsJsonAsync($"employees/{employee.Id}", employee));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> DeleteEmployeeAsync(int id)
    {
        var result = await SendMessageAsync(
            () => _httpClient.DeleteAsync($"employees/{id}"));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> AddSkillAsync(SkillDto skill)
    {
        var result = await SendMessageAsync(
            () => _httpClient.PostAsJsonAsync("skills", skill));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> UpdateSkillAsync(SkillDto skill)
    {
        var result = await SendMessageAsync(
            () => _httpClient.PutAsJsonAsync($"skills/{skill.Id}", skill));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> DeleteSkillAsync(int id)
    {
        var result = await SendMessageAsync(
            () => _httpClient.DeleteAsync($"skills/{id}"));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> AddSkillToEmployeeAsync(int employeeId, int skillId)
    {
        var result = await SendMessageAsync(
            () => _httpClient.PostAsync($"employees/{employeeId}/skills/{skillId}", null));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result> RemoveSkillFromEmployeeAsync(int employeeId, int skillId)
    {
        var result = await SendMessageAsync(
            () => _httpClient.DeleteAsync($"employees/{employeeId}/skills/{skillId}"));
        return result.IsFailed
            ? Result.Fail(result.Errors)
            : Result.Ok();
    }

    public async Task<Result<IEnumerable<SkillDto>>>
        GetEmployeeSkillsAsync(int employeeId)
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync($"employees/{employeeId}/skills"));
        if (result.IsFailed)
        {
            return Result.Fail<IEnumerable<SkillDto>>(result.Errors);
        }

        var skills = await result.Value.Content.ReadFromJsonAsync<IEnumerable<SkillDto>>();
        return Result.Ok(skills)!;
    }

    public async Task<Result<IEnumerable<EmployeeDto>>>
        GetSkillEmployeesAsync(int skillId)
    {
        var result = await SendMessageAsync(
            () => _httpClient.GetAsync($"skills/{skillId}/employees"));
        if (result.IsFailed)
        {
            return Result.Fail<IEnumerable<EmployeeDto>>(result.Errors);
        }

        var employees = await result.Value.Content.ReadFromJsonAsync<IEnumerable<EmployeeDto>>();
        return Result.Ok(employees)!;
    }
}