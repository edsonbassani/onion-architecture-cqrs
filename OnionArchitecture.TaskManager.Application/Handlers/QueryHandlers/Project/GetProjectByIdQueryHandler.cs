using OnionArchitecture.TaskManager.Application.Abstractions;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Queries.Project;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.Project
{
    public class GetProjectByIdQueryHandler : ServiceBase
    {
        private readonly IProjectService _projectService;

        public GetProjectByIdQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ProjectDTO> Handle(GetProjectByIdQuery query)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _projectService.GetProjectByIdAsync(query.Id);
            });
        }
    }
}
