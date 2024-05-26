using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.Project
{
    public class CreateProjectCommand
    {
        public required int ProjectId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
