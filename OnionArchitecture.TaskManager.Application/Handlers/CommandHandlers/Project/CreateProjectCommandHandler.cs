using OnionArchitecture.TaskManager.Application.Abstractions;
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
    public class CreateProjectCommandHandler : ServiceBase
    {
        private readonly IProjectService _projectService;

        public CreateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(CreateProjectCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    var projectDto = new ProjectDTO
                    {
                        Name = command.Name,
                        CreatedBy = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = 1
                    };
                    await _projectService.AddProjectAsync(projectDto);
                });
        }
    }
}
