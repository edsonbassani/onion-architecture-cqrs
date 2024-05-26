using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask;
using OnionArchitecture.TaskManager.Application.Features.Queries.ProjectTask;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.ProjectTask;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.ProjectTask;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectTasksController : Controller
    {
        private readonly CreateProjectTaskCommandHandler _createHandler;
        private readonly UpdateProjectTaskCommandHandler _updateHandler;
        private readonly DeleteProjectTaskCommandHandler _deleteHandler;
        private readonly GetProjectTaskByIdQueryHandler _getByIdHandler;
        private readonly GetAllProjectTasksQueryHandler _getAllHandler;

        public ProjectTasksController(
            CreateProjectTaskCommandHandler createHandler,
            UpdateProjectTaskCommandHandler updateHandler,
            DeleteProjectTaskCommandHandler deleteHandler,
            GetProjectTaskByIdQueryHandler getByIdHandler,
            GetAllProjectTasksQueryHandler getAllHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectTaskCommand command)
        {
            await _createHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectTaskCommand command)
        {
            await _updateHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectTaskCommand { Id = id };
            await _deleteHandler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectTaskByIdQuery { Id = id };
            var result = await _getByIdHandler.Handle(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProjectTasksQuery();
            var result = await _getAllHandler.Handle(query);
            return Ok(result);
        }
    }
}
