using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Features.Commands.ProjectTask
{
    public class UpdateProjectTaskCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentTaskId { get; set; }
        public int ProjectId { get; set; }
        public int Assignment { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
