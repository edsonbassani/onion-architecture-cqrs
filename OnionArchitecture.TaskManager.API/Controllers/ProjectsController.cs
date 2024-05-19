using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;
using OnionArchitecture.TaskManager.Core.Models;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectDTO projectDto)
        {
            await _projectService.AddProjectAsync(projectDto);
            return CreatedAtAction(nameof(CreateProject), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectDTO projectDto)
        {
            await _projectService.UpdateProjectAsync(projectDto);
            return Ok(projectDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok($"{{ \"Project successfully deleted {id}\" }}");
        }
    }
}
