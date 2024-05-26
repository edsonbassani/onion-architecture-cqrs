using OnionArchitecture.TaskManager.Application.Abstractions;
using OnionArchitecture.TaskManager.Application.DTOs;
using OnionArchitecture.TaskManager.Application.Features.Queries.User;
using OnionArchitecture.TaskManager.Application.Interfaces;
using OnionArchitecture.TaskManager.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Handlers.QueryHandlers.User
{
    public class GetAllUsersQueryHandler : ServiceBase
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery query)
        {
            return await ExecuteWithLoggingAsync(_userService.GetAllUsersAsync);
        }
    }
}
