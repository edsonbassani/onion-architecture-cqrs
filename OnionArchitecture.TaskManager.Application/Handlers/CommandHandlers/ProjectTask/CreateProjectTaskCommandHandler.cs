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
    public class CreateProjectTaskCommandHandler : ServiceBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public CreateProjectTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task Handle(CreateProjectTaskCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    var projectTaskDto = new ProjectTaskDTO
                    {
                        ProjectId = command.ProjectId,
                        Name = command.Name,
                        ParentTaskId = command.ParentTaskId,
                        StartDate = command.StartDate,
                        DueDate = command.DueDate,
                        Assignment = command.Assignment,
                        CompletionDate = command.CompletionDate,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 1,
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = 1
                    };
                    await _projectTaskService.AddProjectTaskAsync(projectTaskDto);
                }
            );
        }
    }
}
