using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectTasksController : Controller
    {
        private readonly IProjectTaskService _projectTasksService;

        public ProjectTasksController(IProjectTaskService projectTasksService)
        {
            _projectTasksService = projectTasksService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProjectTasks(int projectId)
        {
            var projectTasks = await _projectTasksService.GetAllProjectTasksAsync(projectId);
            return Ok(projectTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectTaskById(int id)
        {
            var project = await _projectTasksService.GetProjectTaskByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectTask(ProjectTaskDTO projectTaskDto)
        {
            await _projectTasksService.AddProjectTaskAsync(projectTaskDto);
            return CreatedAtAction(nameof(CreateProjectTask), new { id = projectTaskDto.Id }, projectTaskDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProjectTask(ProjectTaskDTO projectTaskDto)
        {
            await _projectTasksService.UpdateProjectTaskAsync(projectTaskDto);
            return Ok(projectTaskDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectTask(int id)
        {
            await _projectTasksService.DeleteProjectTaskAsync(id);
            return Ok($"{{ \"Project Task successfully deleted {id}\" }}");
        }
    }
}
