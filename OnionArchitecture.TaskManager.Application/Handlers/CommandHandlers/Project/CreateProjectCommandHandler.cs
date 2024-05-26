using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Commands.Project;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.Project
{
    public class CreateProjectCommandHandler
    {
        private readonly IProjectService _projectService;

        public CreateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(CreateProjectCommand command)
        {
            var projectDto = new ProjectDTO
            {
                Id = command.ProjectId,
                Name = command.Name,
            };
            await _projectService.AddProjectAsync(projectDto);
        }
    }
}
