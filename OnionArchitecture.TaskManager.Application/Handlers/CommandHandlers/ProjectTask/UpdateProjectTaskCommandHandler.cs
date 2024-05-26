using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.ProjectTask
{
    public class UpdateProjectTaskCommandHandler
    {
        private readonly IProjectTaskService _projectTaskService;

        public UpdateProjectTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task Handle(UpdateProjectTaskCommand command)
        {
            var projectTaskDto = new ProjectTaskDTO
            {
                Id = command.TaskId,
                Name = command.Name
            };
            await _projectTaskService.UpdateProjectTaskAsync(projectTaskDto);
        }
    }
}
