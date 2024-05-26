using OnionArchitecture.TaskManager.Application.Abstractions;
using OnionArchitecture.TaskManager.Application.Features.Commands.Project;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.Project
{
    public class DeleteProjectCommandHandler : ServiceBase
    {
        private readonly IProjectService _projectService;

        public DeleteProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(DeleteProjectCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    await _projectService.DeleteProjectAsync(command.Id);
                }
            );
        }
    }
}
