using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Context
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : 
            base(options) { }

        public DbSet<EmployeeTask> EmployeeTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}