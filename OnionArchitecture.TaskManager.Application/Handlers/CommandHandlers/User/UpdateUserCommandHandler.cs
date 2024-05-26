using OnionArchitecture.TaskManager.Application.Abstractions;
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
    public class UpdateUserCommandHandler : ServiceBase
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(UpdateUserCommand command)
        {
            await ExecuteWithLoggingAsync(
                async () =>
                {
                    var userDto = new UserDTO
                    {
                        Id = command.Id,
                        Name = command.Name,
                        FirstName = command.FirstName,
                        Login = command.Login,
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = 1
                    };
                    await _userService.UpdateUserAsync(userDto);
                }
            );
        }
    }
}
