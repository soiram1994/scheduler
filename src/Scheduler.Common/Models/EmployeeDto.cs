namespace Scheduler.Common.Models;

public record EmployeeDto(int Id, string Name, string Email, IEnumerable<SkillDto> Skills);