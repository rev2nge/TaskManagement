using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaskManagement.Infrastructure.Context
{
    public class TaskDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
    {
        public TaskDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("TaskManagement.Infrastructure"));

            return new TaskDbContext(optionsBuilder.Options);
        }
    }
}
