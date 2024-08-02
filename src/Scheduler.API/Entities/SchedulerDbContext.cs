using Microsoft.EntityFrameworkCore;

namespace Scheduler.API.Entities;

public class SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : DbContext(options)
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Employee> Employees { get; set; }
}