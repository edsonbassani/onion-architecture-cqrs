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
    public class GetProjectTaskByIdQueryHandler
    {
        private readonly IProjectTaskService _projectTaskService;

        public GetProjectTaskByIdQueryHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        public async Task<ProjectTaskDTO> Handle(GetProjectTaskByIdQuery query)
        {
            return await _projectTaskService.GetProjectTaskByIdAsync(query.Id);
        }
    }
}
