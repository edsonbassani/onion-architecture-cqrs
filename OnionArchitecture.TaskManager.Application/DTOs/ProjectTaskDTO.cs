using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.DTOs
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentTaskId { get; set; }
        public int ProjectId { get; set; }
        public int Assignment { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
    }
}
