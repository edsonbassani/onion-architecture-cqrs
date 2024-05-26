using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask
{
    public class CreateProjectTaskCommand
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
