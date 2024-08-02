using FluentResults;
using Scheduler.Common.Models;

namespace Scheduler.MAUI.Services.Skills;

public interface ISkillsService
{
    Task<Result<IEnumerable<SkillDto>>> GetSkillsAsync();
    Task<Result<SkillDto>> GetSkillAsync(int id);
    Task<Result> AddSkillAsync(SkillDto skill);
}