using Microsoft.AspNetCore.Mvc;
using TaskTrack.Services.Contracts;
using TaskTrack.DAL.Entities;

namespace TaskTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound($"Project with ID {id} not found.");

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProject = await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.ProjectId}, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != project.ProjectId)
                return BadRequest("Project ID mismatch.");

            var updatedProject = await _projectService.UpdateProjectAsync(project);
            if (updatedProject == null)
                return NotFound($"Project with ID {id} not found.");

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deletedProject = await _projectService.DeleteProjectAsync(id);
            if (deletedProject == null)
                return NotFound($"Project with ID {id} not found.");

            return Ok(deletedProject); 
        }
    }
}
