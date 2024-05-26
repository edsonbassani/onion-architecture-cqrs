using OnionArchitecture.TaskManager.Application.Abstractions;
using OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.ProjectTask
{
    public class DeleteProjectTaskCommandHandler : ServiceBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public DeleteProjectTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task Handle(DeleteProjectTaskCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    await _projectTaskService.DeleteProjectTaskAsync(command.Id);
                }
            );
        }
    }
}
