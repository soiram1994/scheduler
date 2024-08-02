using Microsoft.EntityFrameworkCore;
using Scheduler.API.Entities;

namespace Scheduler.API.Repos;

public class EmployeesRepo(SchedulerDbContext context)
{
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeAsync(int id)
    {
        return await context.Employees.FindAsync(id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
        return employee;
    }
}

public class SkillsRepo(SchedulerDbContext context)
{
    public async Task<IEnumerable<Skill>> GetSkillsAsync()
    {
        return await context.Skills.ToListAsync();
    }

    public async Task<Skill> GetSkillAsync(int id)
    {
        return await context.Skills.FindAsync(id);
    }

    public async Task<Skill> AddSkillAsync(Skill skill)
    {
        context.Skills.Add(skill);
        await context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill> UpdateSkillAsync(Skill skill)
    {
        context.Skills.Update(skill);
        await context.SaveChangesAsync();
        return skill;
    }
}