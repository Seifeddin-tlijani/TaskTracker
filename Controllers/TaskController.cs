using Microsoft.AspNetCore.Mvc;
using TaskTrack.Services.Contracts;

namespace TaskTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.Entities.Task>>> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }


        [HttpPost]
        public async Task<ActionResult<DAL.Entities.Task>> AddTask(DAL.Entities.Task task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null.");
            }

            await _taskService.AddTaskAsync(task);
            return StatusCode(201, task);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, DAL.Entities.Task task)
        {
            if (id != task.TaskId)
            {
                return BadRequest("Task ID mismatch.");
            }

            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            try
            {
                await _taskService.UpdateTaskAsync(task);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Task with ID {id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                await _taskService.DeleteTaskAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Task with ID {id} not found.");
            }
        }
    }


}
