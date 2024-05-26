using OnionArchitecture.TaskManager.Application.Abstractions;
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
    public class UpdateProjectTaskCommandHandler : ServiceBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public UpdateProjectTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task Handle(UpdateProjectTaskCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    var projectTaskDto = new ProjectTaskDTO
                    {
                        Id = command.Id,
                        Name = command.Name,
                        ParentTaskId = command.ParentTaskId,
                        ProjectId = command.ProjectId,
                        StartDate = command.StartDate,
                        DueDate = command.DueDate,
                        CompletionDate = command.CompletionDate,
                        Assignment = command.Assignment,
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = 1
                    };
                    await _projectTaskService.UpdateProjectTaskAsync(projectTaskDto);
                }
            );
        }
    }
}
