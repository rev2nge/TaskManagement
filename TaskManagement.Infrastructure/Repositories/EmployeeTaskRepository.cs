using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly TaskDbContext _context;

        public EmployeeTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeTask>> GetAllTasksAsync()
        {
            return await _context.EmployeeTasks.ToListAsync();
        }
    }
}