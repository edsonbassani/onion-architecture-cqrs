using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Commands.User;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.User
{
    public class CreateUserCommandHandler
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(CreateUserCommand command)
        {
            var userDto = new UserDTO
            {
                Name = command.Name,
                Login = command.Login,
                FirstName = command.FirstName,
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                ModifiedAt = DateTime.Now,
                ModifiedBy = 1
            };
            await _userService.AddUserAsync(userDto);
        }
    }
}
