using OnionArchitecture.TaskManager.Application.Abstractions;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Queries.ProjectTask;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.ProjectTask
{
    public class GetAllProjectTasksQueryHandler : ServiceBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public GetAllProjectTasksQueryHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task<IEnumerable<ProjectTaskDTO>> Handle(GetAllProjectTasksQuery query)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _projectTaskService.GetAllProjectTasksAsync(query.ProjectId);
            });
        }
    }
}
