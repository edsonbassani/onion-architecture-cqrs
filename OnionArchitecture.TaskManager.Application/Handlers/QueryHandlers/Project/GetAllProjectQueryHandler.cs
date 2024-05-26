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
    public class GetAllProjectQueryHandler
    {
        private readonly IProjectService _projectService;

        public GetAllProjectQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IEnumerable<ProjectDTO>> Handle(GetAllProjectsQuery query)
        {
            return await _projectService.GetAllProjectsAsync();
        }
    }
}
