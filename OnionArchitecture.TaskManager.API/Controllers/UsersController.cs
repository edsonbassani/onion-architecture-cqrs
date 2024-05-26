using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Commands.User;
using OnionArchitecture.TaskManager.Application.Features.Queries.User;
using OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.User;
using OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.User;
using OnionArchitecture.TaskManager.Application.Interfaces;

namespace OnionArchitecture.TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly CreateUserCommandHandler _createHandler;
        private readonly UpdateUserCommandHandler _updateHandler;
        private readonly DeleteUserCommandHandler _deleteHandler;
        private readonly GetUserByIdQueryHandler _getByIdHandler;
        private readonly GetAllUsersQueryHandler _getAllHandler;

        public UsersController(
            CreateUserCommandHandler createHandler,
            UpdateUserCommandHandler updateHandler,
            DeleteUserCommandHandler deleteHandler,
            GetUserByIdQueryHandler getByIdHandler,
            GetAllUsersQueryHandler getAllHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            var command = new CreateUserCommand
            {
                Name = userDto.Name
            };
            await _createHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDTO userDto)
        {
            var command = new UpdateUserCommand
            {
               Id = userDto.Id
            };
            await _updateHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _deleteHandler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _getByIdHandler.Handle(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _getAllHandler.Handle(query);
            return Ok(result);
        }
    }
}
