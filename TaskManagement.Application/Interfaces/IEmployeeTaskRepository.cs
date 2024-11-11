using TaskManagement.Domain.Models;

namespace TaskManagement.Application.Interfaces
{
    public interface IEmployeeTaskRepository
    {
        Task<IEnumerable<EmployeeTask>> GetAllTasksAsync();
    }
}