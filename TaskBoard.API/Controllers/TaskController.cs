using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskBoard.API.Interfaces;

namespace TaskBoard.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> ListTasks()
        {
            return Ok(await _taskService.ListTasks());
        }

        [HttpGet("tasks/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            return Ok(await _taskService.GetById(id));
        }

        [HttpPost("tasks/newtask")]
        public async Task<IActionResult> PostTask(TaskModel taskModel)
        {
            return Ok(await _taskService.PostTask(taskModel));
        }

        [HttpPut("tasks/{id}/updatetask")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel task)
        {
            return Ok(await _taskService.UpdateTask(task));
        }

        [HttpDelete("tasks/{id}/deletetask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await _taskService.DeleteTask(id));
        }
    }
}
