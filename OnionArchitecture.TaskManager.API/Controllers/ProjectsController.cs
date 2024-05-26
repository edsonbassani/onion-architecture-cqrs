﻿using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Commands.Project;
using OnionArchitecture.TaskManager.Application.Features.Queries.Project;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.Project;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.Project;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;
using OnionArchitecture.TaskManager.Core.Models;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly CreateProjectCommandHandler _createHandler;
        private readonly UpdateProjectCommandHandler _updateHandler;
        private readonly DeleteProjectCommandHandler _deleteHandler;
        private readonly GetProjectByIdQueryHandler _getByIdHandler;
        private readonly GetAllProjectsQueryHandler _getAllHandler;

        private readonly IProjectService _projectService;

        public ProjectsController(
            CreateProjectCommandHandler createHandler,
            UpdateProjectCommandHandler updateHandler,
            DeleteProjectCommandHandler deleteHandler,
            GetProjectByIdQueryHandler getByIdHandler,
            GetAllProjectsQueryHandler getAllHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDTO projectDto)
        {
            var command = new CreateProjectCommand
            {
                Name = projectDto.Name
            };
            await _createHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectDTO projectDto)
        {
            var command = new UpdateProjectCommand
            {
                 Id = projectDto.Id
            };
            await _updateHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _deleteHandler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery { Id = id };
            var result = await _getByIdHandler.Handle(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProjectsQuery();
            var result = await _getAllHandler.Handle(query);
            return Ok(result);
        }
    }
}
