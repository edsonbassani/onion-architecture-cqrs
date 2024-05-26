using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask
{
    public class UpdateProjectTaskCommand
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int ParentTaskId { get; set; }
        public required int ProjectId { get; set; }
        public required int Assignment { get; set; }
        public required DateTime CompletionDate { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime DueDate { get; set; }
    }
}
