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
    public class CreateProjectTaskCommandHandler
    {
        private readonly IProjectTaskService _projectTaskService;

        public CreateProjectTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task Handle(CreateProjectTaskCommand command)
        {
            var projectTaskDto = new ProjectTaskDTO
            {
                ProjectId = command.ProjectId,
                Name = command.Name,
            };
            await _projectTaskService.AddProjectTaskAsync(projectTaskDto);
        }
    }
}
