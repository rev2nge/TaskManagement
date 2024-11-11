using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Models;

namespace TaskManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IEmployeeTaskRepository _taskRepository;

        public TasksController(IEmployeeTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("GetTasks")]
        public async Task<ActionResult<IEnumerable<EmployeeTask>>> GetTasks()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }
    }
}