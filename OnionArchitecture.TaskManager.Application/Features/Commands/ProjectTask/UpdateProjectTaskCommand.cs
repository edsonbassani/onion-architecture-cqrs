using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask
{
    public class UpdateProjectTaskCommand
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
