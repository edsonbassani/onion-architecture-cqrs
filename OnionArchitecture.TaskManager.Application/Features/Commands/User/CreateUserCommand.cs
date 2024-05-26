using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.User
{
    public class CreateUserCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
