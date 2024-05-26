using OnionArchitecture.TaskManager.Application.Features.Commands.User;
using OnionArchitecture.TaskManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.CommandHandlers.User
{
    public class DeleteUserCommandHandler
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(DeleteUserCommand command)
        {
            await _userService.DeleteUserAsync(command.Id);
        }
    }
}
