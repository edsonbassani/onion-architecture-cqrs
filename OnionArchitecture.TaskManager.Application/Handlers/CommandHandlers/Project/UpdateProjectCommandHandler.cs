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
    public class UpdateProjectCommandHandler
    {
        private readonly IProjectService _projectService;

        public UpdateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(UpdateProjectCommand command)
        {
            var projectDto = new ProjectDTO
            {
                Id = command.Id,
                Name = command.Name,
                ModifiedAt = DateTime.Now,
                ModifiedBy = 1
            };
            await _projectService.UpdateProjectAsync(projectDto);
        }
    }
}
