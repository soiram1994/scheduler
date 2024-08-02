using FluentResults;
using Scheduler.Common.Models;
using Scheduler.MAUI.Clients;

namespace Scheduler.MAUI.Services.Skills;

public class SkillsService(ISchedulerApiClient schedulerApiClient) : ISkillsService
{
    public async Task<Result<IEnumerable<SkillDto>>> GetSkillsAsync()
    {
        return await schedulerApiClient.GetSkillsAsync();
    }

    public async Task<Result<SkillDto>> GetSkillAsync(int id)
    {
        return await schedulerApiClient.GetSkillAsync(id);
    }

    public async Task<Result> AddSkillAsync(SkillDto skill)
    {
        return await schedulerApiClient.AddSkillAsync(skill);
    }
      
    public async Task<Result> UpdateSkillAsync(SkillDto skill)
    {
        return await schedulerApiClient.UpdateSkillAsync(skill);
    }
}