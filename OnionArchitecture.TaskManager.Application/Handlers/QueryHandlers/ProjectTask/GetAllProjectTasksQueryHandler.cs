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
    public class GetAllProjectTasksQueryHandler
    {
        private readonly IProjectTaskService _projectTaskService;

        public GetAllProjectTasksQueryHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task<IEnumerable<ProjectTaskDTO>> Handle(GetAllProjectTasksQuery query)
        {
            return await _projectTaskService.GetAllProjectTasksAsync(query.ProjectId);
        }
    }
}
